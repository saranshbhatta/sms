namespace SchoolManagement.Domain.CustomEntityColumns
{
    public class FullyAuditedEntity : Entity
    {
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public int? LastModifiedUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletionTime { get; set; }
        public int DeletionUserId { get; set; }
    }
}
