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
    /// Gets or Sets DiagnosisType
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DiagnosisType
    {
        /// <summary>
        /// Enum MainEnum for Main
        /// </summary>
        [EnumMember(Value = "Main")]
        MainEnum = 0,
        /// <summary>
        /// Enum ConcomitantEnum for Concomitant
        /// </summary>
        [EnumMember(Value = "Concomitant")]
        ConcomitantEnum = 1,
        /// <summary>
        /// Enum ComplicationEnum for Complication
        /// </summary>
        [EnumMember(Value = "Complication")]
        ComplicationEnum = 2
    }
}
