// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net5.Rest.Infrastructure.Data.Entities
{
    public partial class GetStudentGradesResult
    {
        public int EnrollmentID { get; set; }
        public decimal? Grade { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
