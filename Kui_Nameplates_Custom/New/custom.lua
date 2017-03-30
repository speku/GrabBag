--[[
-- Custom code injector template for Kui_Nameplates_Core
-- By Kesava at curse.com
--]]
local folder,ns=...
local addon = KuiNameplates
local core = KuiNameplatesCore
local mod = addon:NewPlugin('CustomInjector',101)

local multiplier = 2

local clrBlue = {0,1,1,1}

local whiteList = {
    ["Sha Corruption"] = clrBlue
}

local elapsedFrames = 0
local toElapse = 2
local redrawStarted = false
local speed = 0.001

local rotationIndex = 1
local rotations = {
    MoveViewUpStart,
    MoveViewDownStart
}
local cancelRotations = {
    MoveViewUpStop,
    MoveViewDownStop
}

local function Redraw()
    redrawStarted = true
    elapsedFrames = 0
    rotationIndex = (rotationIndex + 1) % 2
    rotations[rotationIndex + 1](speed)
end

local f = CreateFrame("frame")
f:SetScript("OnUpdate", function()
    if redrawStarted then 
        if elapsedFrames < toElapse then
            elapsedFrames = elapsedFrames + 1
        else
            elapsedFrames = 0
            redrawStarted = false 
            cancelRotations[rotationIndex + 1]()
        end
    end
end)

function mod:Enlarge(f)
    local clr = whiteList[f.SpellName:GetText()] 
    if clr then
        f.scale = f:GetScale()
        f:SetScale(f.scale * multiplier)
        f.statusBarColor = f.HealthBar:GetStatusBarColor()
        f.HealthBar:SetStatusBarColor(unpack(clr))
        Redraw()
    end
end

function mod:Shrink(f)
    f:SetScale(f.scale)
    f.HealthBar:SetStatusBarColor(f.statusBarColor)
    Redraw()
end

-- initialise ##################################################################
function mod:Initialise()
    self:RegisterMessage("CastBarShow", "Enlarge")
    self:RegisterMessage("CastBarHide", "Shrink")
end
