using System;

namespace Survello.Services.DTOEntities
{
    public class ListFormsDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Title { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
    }
}
