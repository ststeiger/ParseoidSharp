
var parsoid = require('parsoid');

module.exports = function (callback, wikiText)
{
    // callback(null, '{ "abc":"def", "ghi":123}'); // error - object returned is not a json-object
    // callback(null, { "abc": "def", "ghi": 1234 });

    // callback(null, mediaWiki);


    function dumpObject(obj, level, cache)
    {
        if(level == null)
            level = 0;

        if(cache == null)
            cache = [];

        var output ="";
        for (var property in obj)
        {
            // console.log("prop:", property);

            var value = obj[property];
            var valueType = typeof(value);
            var objType = typeof(obj);

            // console.log("valuetype:", valueType);
            if(obj != null && objType === "object" && obj.hasOwnProperty && obj.hasOwnProperty(property))
            {

                if(value != null && valueType === "object")
                {

                    if (cache.indexOf(value) !== -1)
                        output += "  ".repeat(level) + property + ': ' + "[Circular],\n";
                    else
                    {
                        cache.push(value);
                        if(level > 1)
                            output += "  ".repeat(level) + property + ': "[Object]"\n'
                        else
                            output += "  ".repeat(level) + property + ': {\n' + dumpObject(value, level+1, cache)
                                + "  ".repeat(level) + "},\n";
                    }

                }
                else if(valueType !== "function")
                    output += "  ".repeat(level) + property + ': ' + obj[property] + ",\n";
            }
        } // End Function dumpObject
        
        return output;
    }


    async function parseWiki(markup)
    {
        try 
        {
            var data = await parsoid.parse(markup);
            //console.log(data.out);
            callback(null, data.out);

            // data.out = null;
            // data.env.page.src = null;
            // console.log(data);
            // console.log(dumpObject(data));
            // callback(null, dumpObject(data));
        }
        catch (ex)
        {
            callback(ex, null);
        }
        
    }
    
    parseWiki(wikiText);
    
    /*
    parsoid.parse(mediaWiki)
        //.then(data => callback(null, data.out ) )
        //.then(data => callback(null, JSON.stringify(data)     ) )
        //.then(data => callback(null, JSON.stringify(data, censor(data), 2 )     ) )
        .then(data => callback(null, dumpObject(data)  ) )
        .catch (err => callback(err, null) );
    // callback(null, JSON.stringify(abc) );
    */
    
    // callback(err, null);
};
