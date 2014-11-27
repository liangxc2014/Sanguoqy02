module(..., package.seeall);

function CallFunction(moduleName, functionName, ...)

    local md = _G[moduleName];
    
    if md ~= nil then
        local func = md[functionName]
        if func ~= nil then
            func(...)
        else
            print("Function is not Found! functionName = " .. moduleName .. "." .. functionName)
        end
    else 
        print("Module Name is not Found! moduleName = " .. moduleName)
    end

end

