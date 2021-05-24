namespace Taskie.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TaskieEntitiesModel : DbContext
    {
        public TaskieEntitiesModel()
            : base("name=TaskieEntitiesModel")
        {
        }

        public virtual DbSet<Assigment_table> Assigment_table { get; set; }
        public virtual DbSet<Assignment_Comment_table> Assignment_Comment_table { get; set; }
        public virtual DbSet<Employee_table> Employee_table { get; set; }
        public virtual DbSet<Task_Forward_table> Task_Forward_table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assigment_table>()
                .Property(e => e.Assignment_ID)
                .IsFixedLength();

            modelBuilder.Entity<Assigment_table>()
                .Property(e => e.Assignment_Priority)
                .IsFixedLength();

            modelBuilder.Entity<Assigment_table>()
                .Property(e => e.Created_By_Employee_ID)
                .IsFixedLength();

            modelBuilder.Entity<Assigment_table>()
                .HasMany(e => e.Task_Forward_table)
                .WithOptional(e => e.Assigment_table)
                .HasForeignKey(e => e.Task_Assignment_ID);

            modelBuilder.Entity<Assignment_Comment_table>()
                .Property(e => e.Comment_ID)
                .IsFixedLength();

            modelBuilder.Entity<Assignment_Comment_table>()
                .Property(e => e.Assignment_ID)
                .IsFixedLength();

            modelBuilder.Entity<Employee_table>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Employee_table>()
                .HasMany(e => e.Assigment_table)
                .WithOptional(e => e.Employee_table)
                .HasForeignKey(e => e.Created_By_Employee_ID);

            modelBuilder.Entity<Employee_table>()
                .HasMany(e => e.Task_Forward_table)
                .WithOptional(e => e.Employee_table)
                .HasForeignKey(e => e.Task_Assignment_Forwarded_To_Employee_ID);

            modelBuilder.Entity<Task_Forward_table>()
                .Property(e => e.Task_Assignment_ID)
                .IsFixedLength();

            modelBuilder.Entity<Task_Forward_table>()
                .Property(e => e.Task_Assignment_Forwarded_To_Employee_ID)
                .IsFixedLength();

            modelBuilder.Entity<Task_Forward_table>()
                .Property(e => e.Task_Status)
                .IsFixedLength();

            modelBuilder.Entity<Task_Forward_table>()
                .Property(e => e.Task_Forward_ID)
                .IsFixedLength();
        }
    }
}
