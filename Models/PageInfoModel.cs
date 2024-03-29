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
    public partial class PageInfoModel : IEquatable<PageInfoModel>
    {
        /// <summary>
        /// Gets or Sets Size
        /// </summary>

        [DataMember(Name = "size")]
        public int? Size { get; set; }

        /// <summary>
        /// Gets or Sets Count
        /// </summary>

        [DataMember(Name = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or Sets Current
        /// </summary>

        [DataMember(Name = "current")]
        public int? Current { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PageInfoModel {\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Current: ").Append(Current).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PageInfoModel)obj);
        }

        /// <summary>
        /// Returns true if PageInfoModel instances are equal
        /// </summary>
        /// <param name="other">Instance of PageInfoModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PageInfoModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Size == other.Size ||
                    Size != null &&
                    Size.Equals(other.Size)
                ) &&
                (
                    Count == other.Count ||
                    Count != null &&
                    Count.Equals(other.Count)
                ) &&
                (
                    Current == other.Current ||
                    Current != null &&
                    Current.Equals(other.Current)
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
                if (Size != null)
                    hashCode = hashCode * 59 + Size.GetHashCode();
                if (Count != null)
                    hashCode = hashCode * 59 + Count.GetHashCode();
                if (Current != null)
                    hashCode = hashCode * 59 + Current.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PageInfoModel left, PageInfoModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PageInfoModel left, PageInfoModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
