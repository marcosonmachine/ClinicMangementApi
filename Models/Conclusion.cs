/*
 * MIS.Back
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ApiProject.Models
{

    /// <summary>
    /// Gets or Sets Conclusion
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum Conclusion
    {
        /// <summary>
        /// Enum DiseaseEnum for Disease
        /// </summary>
        [EnumMember(Value = "Disease")]
        DiseaseEnum = 0,
        /// <summary>
        /// Enum RecoveryEnum for Recovery
        /// </summary>
        [EnumMember(Value = "Recovery")]
        RecoveryEnum = 1,
        /// <summary>
        /// Enum DeathEnum for Death
        /// </summary>
        [EnumMember(Value = "Death")]
        DeathEnum = 2
    }
}
