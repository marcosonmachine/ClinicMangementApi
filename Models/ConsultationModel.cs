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
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ConsultationModel : IEquatable<ConsultationModel>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets CreateTime
        /// </summary>
        [Required]

        [DataMember(Name = "createTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Gets or Sets InspectionId
        /// </summary>

        public Guid? InspectionId { get; set; }
        [ForeignKey("InspectionId")]
        [DataMember(Name = "inspectionId")]
        public InspectionModel Inspection { get; set; }

        /// <summary>
        /// Gets or Sets Speciality
        /// </summary>

        [DataMember(Name = "speciality")]
        [ForeignKey("SpecialityId")]
        public SpecialityModel? Speciality { get; set; }
        public Guid? SpecialityId { get; set; }

        /// <summary>
        /// Gets or Sets Comments
        /// </summary>

        [DataMember(Name = "comments")]
        public List<CommentModel> Comments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConsultationModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  InspectionId: ").Append(InspectionId).Append("\n");
            sb.Append("  Speciality: ").Append(Speciality).Append("\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ConsultationModel)obj);
        }

        /// <summary>
        /// Returns true if ConsultationModel instances are equal
        /// </summary>
        /// <param name="other">Instance of ConsultationModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConsultationModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    CreateTime == other.CreateTime ||
                    CreateTime != null &&
                    CreateTime.Equals(other.CreateTime)
                ) &&
                (
                    InspectionId == other.InspectionId ||
                    InspectionId != null &&
                    InspectionId.Equals(other.InspectionId)
                ) &&
                (
                    Speciality == other.Speciality ||
                    Speciality != null &&
                    Speciality.Equals(other.Speciality)
                ) &&
                (
                    Comments == other.Comments ||
                    Comments != null &&
                    Comments.SequenceEqual(other.Comments)
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (CreateTime != null)
                    hashCode = hashCode * 59 + CreateTime.GetHashCode();
                if (InspectionId != null)
                    hashCode = hashCode * 59 + InspectionId.GetHashCode();
                if (Speciality != null)
                    hashCode = hashCode * 59 + Speciality.GetHashCode();
                if (Comments != null)
                    hashCode = hashCode * 59 + Comments.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ConsultationModel left, ConsultationModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConsultationModel left, ConsultationModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
