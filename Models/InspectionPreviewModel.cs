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
    public partial class InspectionPreviewModel : IEquatable<InspectionPreviewModel>
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
        /// Gets or Sets PreviousId
        /// </summary>

        [DataMember(Name = "previousId")]
        public Guid? PreviousId { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [Required]

        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or Sets Conclusion
        /// </summary>
        [Required]

        [DataMember(Name = "conclusion")]
        public Conclusion Conclusion { get; set; }

        /// <summary>
        /// Gets or Sets DoctorId
        /// </summary>
        [Required]

        [DataMember(Name = "doctorId")]
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Gets or Sets Doctor
        /// </summary>
        [Required]

        [MinLength(1)]
        [DataMember(Name = "doctor")]
        public string Doctor { get; set; }

        /// <summary>
        /// Gets or Sets PatientId
        /// </summary>
        [Required]

        [DataMember(Name = "patientId")]
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Gets or Sets Patient
        /// </summary>
        [Required]

        [MinLength(1)]
        [DataMember(Name = "patient")]
        public string Patient { get; set; }

        /// <summary>
        /// Gets or Sets Diagnosis
        /// </summary>
        [Required]

        [DataMember(Name = "diagnosis")]
        public DiagnosisModel Diagnosis { get; set; }

        /// <summary>
        /// Gets or Sets HasChain
        /// </summary>

        [DataMember(Name = "hasChain")]
        public bool? HasChain { get; set; }

        /// <summary>
        /// Gets or Sets HasNested
        /// </summary>

        [DataMember(Name = "hasNested")]
        public bool? HasNested { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InspectionPreviewModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  PreviousId: ").Append(PreviousId).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Conclusion: ").Append(Conclusion).Append("\n");
            sb.Append("  DoctorId: ").Append(DoctorId).Append("\n");
            sb.Append("  Doctor: ").Append(Doctor).Append("\n");
            sb.Append("  PatientId: ").Append(PatientId).Append("\n");
            sb.Append("  Patient: ").Append(Patient).Append("\n");
            sb.Append("  Diagnosis: ").Append(Diagnosis).Append("\n");
            sb.Append("  HasChain: ").Append(HasChain).Append("\n");
            sb.Append("  HasNested: ").Append(HasNested).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InspectionPreviewModel)obj);
        }

        /// <summary>
        /// Returns true if InspectionPreviewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of InspectionPreviewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InspectionPreviewModel other)
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
                    PreviousId == other.PreviousId ||
                    PreviousId != null &&
                    PreviousId.Equals(other.PreviousId)
                ) &&
                (
                    Date == other.Date ||
                    Date != null &&
                    Date.Equals(other.Date)
                ) &&
                (
                    Conclusion == other.Conclusion ||
                    Conclusion != null &&
                    Conclusion.Equals(other.Conclusion)
                ) &&
                (
                    DoctorId == other.DoctorId ||
                    DoctorId != null &&
                    DoctorId.Equals(other.DoctorId)
                ) &&
                (
                    Doctor == other.Doctor ||
                    Doctor != null &&
                    Doctor.Equals(other.Doctor)
                ) &&
                (
                    PatientId == other.PatientId ||
                    PatientId != null &&
                    PatientId.Equals(other.PatientId)
                ) &&
                (
                    Patient == other.Patient ||
                    Patient != null &&
                    Patient.Equals(other.Patient)
                ) &&
                (
                    Diagnosis == other.Diagnosis ||
                    Diagnosis != null &&
                    Diagnosis.Equals(other.Diagnosis)
                ) &&
                (
                    HasChain == other.HasChain ||
                    HasChain != null &&
                    HasChain.Equals(other.HasChain)
                ) &&
                (
                    HasNested == other.HasNested ||
                    HasNested != null &&
                    HasNested.Equals(other.HasNested)
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
                if (PreviousId != null)
                    hashCode = hashCode * 59 + PreviousId.GetHashCode();
                if (Date != null)
                    hashCode = hashCode * 59 + Date.GetHashCode();
                if (Conclusion != null)
                    hashCode = hashCode * 59 + Conclusion.GetHashCode();
                if (DoctorId != null)
                    hashCode = hashCode * 59 + DoctorId.GetHashCode();
                if (Doctor != null)
                    hashCode = hashCode * 59 + Doctor.GetHashCode();
                if (PatientId != null)
                    hashCode = hashCode * 59 + PatientId.GetHashCode();
                if (Patient != null)
                    hashCode = hashCode * 59 + Patient.GetHashCode();
                if (Diagnosis != null)
                    hashCode = hashCode * 59 + Diagnosis.GetHashCode();
                if (HasChain != null)
                    hashCode = hashCode * 59 + HasChain.GetHashCode();
                if (HasNested != null)
                    hashCode = hashCode * 59 + HasNested.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(InspectionPreviewModel left, InspectionPreviewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InspectionPreviewModel left, InspectionPreviewModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
