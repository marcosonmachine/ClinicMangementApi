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
    public partial class CommentModel : IEquatable<CommentModel>
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
        /// Gets or Sets ModifiedDate
        /// </summary>

        [DataMember(Name = "modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [Required]

        [MinLength(1)]
        [DataMember(Name = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets AuthorId
        /// </summary>
        [Required]

        [DataMember(Name = "authorId")]
        public Guid? AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets Author
        /// </summary>
        [Required]

        [DataMember(Name = "author")]
        [ForeignKey("AuthorId")]
        public DoctorModel Author { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>

        [DataMember(Name = "parentId")]
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public CommentModel Parent {get;set;}

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommentModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  ModifiedDate: ").Append(ModifiedDate).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  AuthorId: ").Append(AuthorId).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CommentModel)obj);
        }

        /// <summary>
        /// Returns true if CommentModel instances are equal
        /// </summary>
        /// <param name="other">Instance of CommentModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CommentModel other)
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
                    ModifiedDate == other.ModifiedDate ||
                    ModifiedDate != null &&
                    ModifiedDate.Equals(other.ModifiedDate)
                ) &&
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) &&
                (
                    AuthorId == other.AuthorId ||
                    AuthorId != null &&
                    AuthorId.Equals(other.AuthorId)
                ) &&
                (
                    Author == other.Author ||
                    Author != null &&
                    Author.Equals(other.Author)
                ) &&
                (
                    ParentId == other.ParentId ||
                    ParentId != null &&
                    ParentId.Equals(other.ParentId)
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
                if (ModifiedDate != null)
                    hashCode = hashCode * 59 + ModifiedDate.GetHashCode();
                if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                if (AuthorId != null)
                    hashCode = hashCode * 59 + AuthorId.GetHashCode();
                if (Author != null)
                    hashCode = hashCode * 59 + Author.GetHashCode();
                if (ParentId != null)
                    hashCode = hashCode * 59 + ParentId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CommentModel left, CommentModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CommentModel left, CommentModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
