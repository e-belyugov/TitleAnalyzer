﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace TitleAnalyzer.JsonPageRepository
{
    /// <summary>
    /// DynamicMappingResolver for Json
    /// </summary>
    class DynamicMappingResolver : DefaultContractResolver
    {
        private Dictionary<Type, Dictionary<string, string>> memberNameToJsonNameMap;

        public DynamicMappingResolver(Dictionary<Type, Dictionary<string, string>> memberNameToJsonNameMap)
        {
            this.memberNameToJsonNameMap = memberNameToJsonNameMap;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            Dictionary<string, string> dict;
            string jsonName;
            if (memberNameToJsonNameMap.TryGetValue(member.DeclaringType, out dict) &&
                dict.TryGetValue(member.Name, out jsonName))
            {
                prop.PropertyName = jsonName;
            }
            return prop;
        }
    }
}
