using System.Runtime.Serialization;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ApiProject.Models
{
    public class PaginatedModel<TEntity>() where TEntity : class
    {

        /// <summary>
        /// Gets or Sets Specialties
        /// </summary>
        [DataMember(Name = "specialties")]
        public List<TEntity> Entities { get; set; }


        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name = "pagination")]
        public PageInfoModel Pagination { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaginatedModel<TEntity> {\n");
            sb.Append("  Specialties: ").Append(Entities).Append("\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PaginatedModel<TEntity>)obj);
        }

        /// <summary>
        /// Returns true if PaginatedModel<TEntity> instances are equal
        /// </summary>
        /// <param name="other">Instance of PaginatedModel<TEntity> to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaginatedModel<TEntity> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Entities == other.Entities ||
                    Entities != null &&
                    Entities.SequenceEqual(other.Entities)
                ) &&
                (
                    Pagination == other.Pagination ||
                    Pagination != null &&
                    Pagination.Equals(other.Pagination)
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
                if (Entities != null)
                    hashCode = hashCode * 59 + Entities.GetHashCode();
                if (Pagination != null)
                    hashCode = hashCode * 59 + Pagination.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PaginatedModel<TEntity> left, PaginatedModel<TEntity> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaginatedModel<TEntity> left, PaginatedModel<TEntity> right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}