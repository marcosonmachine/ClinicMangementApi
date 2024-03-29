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
    /// 
    /// </summary>
    [DataContract]
    public partial class IcdRootsReportModel : IEquatable<IcdRootsReportModel>
    {
        /// <summary>
        /// Gets or Sets Filters
        /// </summary>

        [DataMember(Name = "filters")]
        public IcdRootsReportFiltersModel Filters { get; set; }

        /// <summary>
        /// Gets or Sets Records
        /// </summary>

        [DataMember(Name = "records")]
        public List<IcdRootsReportRecordModel> Records { get; set; }

        /// <summary>
        /// Gets or Sets SummaryByRoot
        /// </summary>

        [DataMember(Name = "summaryByRoot")]
        public Dictionary<string, int?> SummaryByRoot { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IcdRootsReportModel {\n");
            sb.Append("  Filters: ").Append(Filters).Append("\n");
            sb.Append("  Records: ").Append(Records).Append("\n");
            sb.Append("  SummaryByRoot: ").Append(SummaryByRoot).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((IcdRootsReportModel)obj);
        }

        /// <summary>
        /// Returns true if IcdRootsReportModel instances are equal
        /// </summary>
        /// <param name="other">Instance of IcdRootsReportModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IcdRootsReportModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Filters == other.Filters ||
                    Filters != null &&
                    Filters.Equals(other.Filters)
                ) &&
                (
                    Records == other.Records ||
                    Records != null &&
                    Records.SequenceEqual(other.Records)
                ) &&
                (
                    SummaryByRoot == other.SummaryByRoot ||
                    SummaryByRoot != null &&
                    SummaryByRoot.SequenceEqual(other.SummaryByRoot)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Filters != null)
                    hashCode = hashCode * 59 + Filters.GetHashCode();
                if (Records != null)
                    hashCode = hashCode * 59 + Records.GetHashCode();
                if (SummaryByRoot != null)
                    hashCode = hashCode * 59 + SummaryByRoot.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(IcdRootsReportModel left, IcdRootsReportModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IcdRootsReportModel left, IcdRootsReportModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
