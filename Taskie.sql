USE [Taskie]
GO
/****** Object:  Table [dbo].[Assigment_table]    Script Date: 5/30/2021 1:09:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assigment_table](
	[Assignment_ID] [nchar](10) NOT NULL,
	[Assignment_Title] [nvarchar](50) NOT NULL,
	[Assignment_Description] [nvarchar](max) NOT NULL,
	[Assignment_Image] [image] NULL,
	[Assignment_Priority] [nchar](10) NOT NULL,
	[Created_By_Employee_ID] [nchar](10) NULL,
 CONSTRAINT [PK_Assigment_table] PRIMARY KEY CLUSTERED 
(
	[Assignment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignment_Comment_table]    Script Date: 5/30/2021 1:09:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment_Comment_table](
	[Comment_ID] [nchar](10) NOT NULL,
	[Assignment_ID] [nchar](10) NULL,
	[Comment] [nvarchar](max) NULL,
	[Comment_Image] [image] NULL,
 CONSTRAINT [PK_Assignment_Comment_table] PRIMARY KEY CLUSTERED 
(
	[Comment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_table]    Script Date: 5/30/2021 1:09:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_table](
	[ID] [nchar](10) NOT NULL,
	[Emp_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee_table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task_Forward_table]    Script Date: 5/30/2021 1:09:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task_Forward_table](
	[Task_Assignment_ID] [nchar](10) NULL,
	[Task_Assignment_Forwarded_To_Employee_ID] [nchar](10) NULL,
	[Task_Status] [nchar](10) NOT NULL,
	[Task_Forward_ID] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Task_Forward_table] PRIMARY KEY CLUSTERED 
(
	[Task_Forward_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assigment_table]  WITH CHECK ADD  CONSTRAINT [FK_CreatedByEmpIDFromAssignmentTable_To_EmpIoyeeIDFromEmpTable] FOREIGN KEY([Created_By_Employee_ID])
REFERENCES [dbo].[Employee_table] ([ID])
GO
ALTER TABLE [dbo].[Assigment_table] CHECK CONSTRAINT [FK_CreatedByEmpIDFromAssignmentTable_To_EmpIoyeeIDFromEmpTable]
GO
ALTER TABLE [dbo].[Assignment_Comment_table]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentIDFromAssignmentCommentTable_To_AssigmentIDFromAssignmentTable] FOREIGN KEY([Assignment_ID])
REFERENCES [dbo].[Assigment_table] ([Assignment_ID])
GO
ALTER TABLE [dbo].[Assignment_Comment_table] CHECK CONSTRAINT [FK_AssignmentIDFromAssignmentCommentTable_To_AssigmentIDFromAssignmentTable]
GO
ALTER TABLE [dbo].[Task_Forward_table]  WITH CHECK ADD  CONSTRAINT [FK_TaskAssigmentIDFromTaskForwardTable_To_AssigmentIDFromAssignmentTable] FOREIGN KEY([Task_Assignment_ID])
REFERENCES [dbo].[Assigment_table] ([Assignment_ID])
GO
ALTER TABLE [dbo].[Task_Forward_table] CHECK CONSTRAINT [FK_TaskAssigmentIDFromTaskForwardTable_To_AssigmentIDFromAssignmentTable]
GO
ALTER TABLE [dbo].[Task_Forward_table]  WITH CHECK ADD  CONSTRAINT [FK_TaskForwardedToEmployeeIDFromTaskForwardTable_To_EmployeeIDFromEmployeeTable] FOREIGN KEY([Task_Assignment_Forwarded_To_Employee_ID])
REFERENCES [dbo].[Employee_table] ([ID])
GO
ALTER TABLE [dbo].[Task_Forward_table] CHECK CONSTRAINT [FK_TaskForwardedToEmployeeIDFromTaskForwardTable_To_EmployeeIDFromEmployeeTable]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is the FK from Assignment Table CreatedBy_EmpID on the Emp_ID from Employee Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Assigment_table', @level2type=N'CONSTRAINT',@level2name=N'FK_CreatedByEmpIDFromAssignmentTable_To_EmpIoyeeIDFromEmpTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK on AssigmnetId in Comment Table from AssignmentTable''s AssignmentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Assignment_Comment_table', @level2type=N'CONSTRAINT',@level2name=N'FK_AssignmentIDFromAssignmentCommentTable_To_AssigmentIDFromAssignmentTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK on the Task Assignment ID from Task Assignment Table, From Assignment ID from Assignment Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task_Forward_table', @level2type=N'CONSTRAINT',@level2name=N'FK_TaskAssigmentIDFromTaskForwardTable_To_AssigmentIDFromAssignmentTable'
GO
