using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListBlazor.Api.Enums;

namespace TodoListBlazor.Api.Enities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public Guid? AssigneeId { get; set; }

        [ForeignKey("AssigneeId")]
        public User Assignee { get; set; }

        public DateTime CreateDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
