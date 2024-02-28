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
    /// Gets or Sets PatientSorting
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PatientSorting
    {
        /// <summary>
        /// Enum NameAscEnum for NameAsc
        /// </summary>
        [EnumMember(Value = "NameAsc")]
        NameAscEnum = 0,
        /// <summary>
        /// Enum NameDescEnum for NameDesc
        /// </summary>
        [EnumMember(Value = "NameDesc")]
        NameDescEnum = 1,
        /// <summary>
        /// Enum CreateAscEnum for CreateAsc
        /// </summary>
        [EnumMember(Value = "CreateAsc")]
        CreateAscEnum = 2,
        /// <summary>
        /// Enum CreateDescEnum for CreateDesc
        /// </summary>
        [EnumMember(Value = "CreateDesc")]
        CreateDescEnum = 3,
        /// <summary>
        /// Enum InspectionAscEnum for InspectionAsc
        /// </summary>
        [EnumMember(Value = "InspectionAsc")]
        InspectionAscEnum = 4,
        /// <summary>
        /// Enum InspectionDescEnum for InspectionDesc
        /// </summary>
        [EnumMember(Value = "InspectionDesc")]
        InspectionDescEnum = 5
    }
}
