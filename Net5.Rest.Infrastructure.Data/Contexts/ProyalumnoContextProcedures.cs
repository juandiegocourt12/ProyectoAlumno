﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Net5.Rest.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.Data.Contexts
{
    public partial class ProyalumnoContext
    {
        private ProyalumnoContextProcedures _procedures;

        public virtual ProyalumnoContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ProyalumnoContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ProyalumnoContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public interface IProyalumnoContextProceduresContract
    {
        Task<int> DeleteOfficeAssignmentAsync(int? InstructorID, CancellationToken cancellationToken = default);
        Task<int> DeletePersonAsync(int? PersonID, CancellationToken cancellationToken = default);
        Task<int> GetDepartmentNameAsync(int? ID, CancellationToken cancellationToken = default);
        Task<List<GetStudentGradesResult>> GetStudentGradesAsync(int? StudentID, CancellationToken cancellationToken = default);
        Task<List<InsertOfficeAssignmentResult>> InsertOfficeAssignmentAsync(int? InstructorID, string Location, CancellationToken cancellationToken = default);
        Task<List<InsertPersonResult>> InsertPersonAsync(string LastName, string FirstName, DateTime? HireDate, DateTime? EnrollmentDate, string Discriminator, CancellationToken cancellationToken = default);
        Task<List<UpdateOfficeAssignmentResult>> UpdateOfficeAssignmentAsync(int? InstructorID, string Location, byte[] OrigTimestamp, CancellationToken cancellationToken = default);
        Task<int> UpdatePersonAsync(int? PersonID, string LastName, string FirstName, DateTime? HireDate, DateTime? EnrollmentDate, string Discriminator, CancellationToken cancellationToken = default);
    }

    public partial class ProyalumnoContextProcedures
    {
        private readonly ProyalumnoContext _context;

        public ProyalumnoContextProcedures(ProyalumnoContext context)
        {
            _context = context;
        }

        public virtual async Task<int> DeleteOfficeAssignmentAsync(int? InstructorID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "InstructorID",
                    Value = InstructorID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[DeleteOfficeAssignment] @InstructorID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> DeletePersonAsync(int? PersonID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "PersonID",
                    Value = PersonID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[DeletePerson] @PersonID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> GetDepartmentNameAsync(int? ID, OutputParameter<string> Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterName = new SqlParameter
            {
                ParameterName = "Name",
                Size = 100,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = Name?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ID",
                    Value = ID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterName,
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[GetDepartmentName] @ID, @Name OUTPUT", sqlParameters, cancellationToken);

            Name.SetValue(parameterName.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetStudentGradesResult>> GetStudentGradesAsync(int? StudentID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "StudentID",
                    Value = StudentID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetStudentGradesResult>("EXEC @returnValue = [dbo].[GetStudentGrades] @StudentID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<InsertOfficeAssignmentResult>> InsertOfficeAssignmentAsync(int? InstructorID, string Location, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "InstructorID",
                    Value = InstructorID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Location",
                    Size = 100,
                    Value = Location ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<InsertOfficeAssignmentResult>("EXEC @returnValue = [dbo].[InsertOfficeAssignment] @InstructorID, @Location", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<InsertPersonResult>> InsertPersonAsync(string LastName, string FirstName, DateTime? HireDate, DateTime? EnrollmentDate, string Discriminator, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "LastName",
                    Size = 100,
                    Value = LastName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "FirstName",
                    Size = 100,
                    Value = FirstName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "HireDate",
                    Value = HireDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "EnrollmentDate",
                    Value = EnrollmentDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "Discriminator",
                    Size = 100,
                    Value = Discriminator ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<InsertPersonResult>("EXEC @returnValue = [dbo].[InsertPerson] @LastName, @FirstName, @HireDate, @EnrollmentDate, @Discriminator", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<UpdateOfficeAssignmentResult>> UpdateOfficeAssignmentAsync(int? InstructorID, string Location, byte[] OrigTimestamp, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "InstructorID",
                    Value = InstructorID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Location",
                    Size = 100,
                    Value = Location ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "OrigTimestamp",
                    Value = OrigTimestamp ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Timestamp,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<UpdateOfficeAssignmentResult>("EXEC @returnValue = [dbo].[UpdateOfficeAssignment] @InstructorID, @Location, @OrigTimestamp", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> UpdatePersonAsync(int? PersonID, string LastName, string FirstName, DateTime? HireDate, DateTime? EnrollmentDate, string Discriminator, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "PersonID",
                    Value = PersonID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "LastName",
                    Size = 100,
                    Value = LastName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "FirstName",
                    Size = 100,
                    Value = FirstName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "HireDate",
                    Value = HireDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "EnrollmentDate",
                    Value = EnrollmentDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "Discriminator",
                    Size = 100,
                    Value = Discriminator ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdatePerson] @PersonID, @LastName, @FirstName, @HireDate, @EnrollmentDate, @Discriminator", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}