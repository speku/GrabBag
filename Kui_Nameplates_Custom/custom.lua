--[[
-- Custom code injector template for Kui_Nameplates_Core
-- By Kesava at curse.com
--]]
local folder,ns=...
local addon = KuiNameplates
local core = KuiNameplatesCore
local mod = addon:NewPlugin('InterruptHighlighter',101)

local prio_one_color = {0,1,1}
local prio_two_color = {1,1,0}
local whitelist = {
  ["Sha Corruption"] = prio_one_color
}

local scalar = 2
local moved = true
local moveScheduled = false
local direction = 1
local distance = 0.001
local cam = CreateFrame("Frame")

cam:SetScript("OnUpdate",function()
  if moveScheduled then
    moveScheduled = false
  elseif not moved then
    MoveViewUpStop()
    MoveViewDownStop()
    moved = true
  end
end)

local function update()
    (direction >= 0 and MoveViewUpStart or MoveViewDownStart)(distance)
    direction = direction * -1
    moveScheduled = true
    moved = false
end

function mod:UNIT_SPELLCAST_START(event,unitFrame,unitid,spell)
    local color = whitelist[spell]
    if not color then return end
    unitFrame.oldScale = unitFrame:GetScale()
    local statusBarTexture = unitFrame.HealthBar:GetStatusBarTexture()
    unitFrame.oldColor = {statusBarTexture:GetVertexColor()}
    unitFrame:SetScale(unitFrame.oldScale * scalar)
    statusBarTexture:SetVertexColor(unpack(color))
    unitFrame:SetFrameLevel(unitFrame:GetFrameLevel())
    update()
end

function mod:UNIT_SPELLCAST_STOP(event,unitFrame,unitid,spell)
  unitFrame:SetScale(unitFrame.oldScale)
  unitFrame.HealthBar:GetStatusBarTexture():SetVertexColor(unpack(unitFrame.oldColor))
  unitFrame:SetFrameLevel(unitFrame:GetFrameLevel())
  update()
end


function mod:Initialise()
    self:RegisterUnitEvent("UNIT_SPELLCAST_START")
    self:RegisterUnitEvent("UNIT_SPELLCAST_STOP")
end
