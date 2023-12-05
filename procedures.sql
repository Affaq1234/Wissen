
use [Wissen]
--============================================ Tables ======================================================================
create table Community
(
  ID int identity(1,1),
  Name nvarchar(50) not null,
  Type nvarchar(50) not null,
  Image varbinary(MAX) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key(ID)
);
create table Assessment
(
 ID int identity(1,1),
 Title nvarchar(500) not null,
 Assignment nvarchar(1000) not null,
 TeacherID int not null,
 StudentID int not null,
 CreatedAT datetime not null,
 UpdatedAT datetime not null,
 Active bit not null,
 primary key(ID),
 foreign key (TeacherID) references Community(ID)
);

create table AssessmentSubmission
(
 AssignmentID int not null,
 TeacherID int not null,
 StudentID int not null,
 [Filename] nvarchar(500) not null,
 [File] varbinary(MAX) not null,
 foreign key (TeacherID) references Community(ID),
 foreign key (StudentID) references Community(ID),
 CreatedAT datetime not null,
 UpdatedAT datetime not null,
 Active bit not null
);

create table Favourites(
 TeacherID int not null,
 StudentID int not null,
 foreign key (TeacherID) references Community(ID),
 foreign key (StudentID) references Community(ID),
 CreatedAT datetime not null,
 UpdatedAT datetime not null,
 Active bit not null
);

create table Payments
(
  ID int identity(1,1),
  StudentID int not null,
  TeacherID int not null,
  BookingID int not null,
  Amount int not null,
  PaymentMethod nvarchar(100),
  Status nvarchar(10),
  foreign key (TeacherID) references Community(ID),
  foreign key (StudentID) references Community(ID),
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key(ID)
);

create table Credential
(
  ID int not null,
  Email nvarchar(50) not null,
  Password nvarchar(50) not null,
  foreign key (ID) references Community(ID),
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key(ID)
);

create table Teachers
(
  TeacherID int not null,
  Qualification nvarchar(150) not null,
  Expertise nvarchar(150) not null,
  HourlyRate int not null,
  Availability nvarchar(250) not null,
  Location nvarchar(250) not null,
  foreign key (TeacherID) references Community(ID),
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null
);

create table Bookings
(
  ID int identity(1,1),
  StudentID int not null,
  TeacherID int not null,
  Subject nvarchar(150) not null,
  StartTime nvarchar(50) not null,
  EndTime nvarchar(50) not null,
  Date datetime not null,
  Status nvarchar(100) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key(ID),
  foreign key (TeacherID) references Community(ID),
 foreign key (StudentID) references Community(ID)
);

create table Students
(
  StudentID int not null, 
  Class nvarchar(100) not null,
  Subjects nvarchar(300) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
 foreign key (StudentID) references Community(ID),
);
create table Conversations
(
  ConversationID int identity(1,1),
  TeacherID int not null,
  StudentID int not null,
  CreatedAT datetime not null,
  LastChecked datetime not null,
  UpdatedAT datetime not null,
  Active bit not null
  primary key(ConversationID),
  foreign key (TeacherID) references Community(ID),
 foreign key (StudentID) references Community(ID)
);

create table Messages
(
  ConversationID int not null,
  Message nvarchar(500) not null,
  SenderID int not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  foreign key (SenderID) references Community(ID)
);

create table [Messages(Audit)]
(
  ConversationID int not null,
  Message nvarchar(500) not null,
  SenderID int not null,
  ConversationID_Up int,
  Message_Up nvarchar(500),
  SenderID_Up int,
  CreatedAT datetime not null,
  UpdatedAT datetime,
  DeletedAT datetime,
  Active bit not null
);

create table [Credentials(Audit)]
(
  ID int not null,
  Email nvarchar(50) not null,
  Password nvarchar(50) not null,
  ID_Up int,
  Email_Up nvarchar(50),
  Password_Up nvarchar(50),
  CreatedAT datetime not null,
  UpdatedAT datetime,
  DeletedAT datetime,
  Active bit not null,
);

create table Notification
(
  ID int identity(1,1),
  UserID int not null,
  Seen bit not null,
  Message nvarchar(MAX) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key(ID),
  foreign key (UserID) references Community(ID)
);

create table [Payments(Audit)]
(
  ID int not null,
  StudentID int not null,
  TeacherID int not null,
  BookingID int not null,
  Amount int not null,
  PaymentMethod nvarchar(100),
  Status nvarchar(10),
  ID_Up int,
  StudentID_Up int,
  TeacherID_Up int,
  BookingID_Up int,
  Amount_Up int,
  PaymentMethod_Up nvarchar(100),
  Status_Up nvarchar(10),
  CreatedAT datetime not null,
  UpdatedAT datetime,
  DeletedAT datetime,
  Active bit not null
);

create table [Conversations(Audit)]
(
  ConversationID int not null,
  TeacherID int not null,
  StudentID int not null,
  LastChecked datetime not null,
  ConversationID_Up int,
  TeacherID_Up int,
  StudentID_Up int,
  LastChecked_Up datetime,
  CreatedAT datetime not null,
  UpdatedAT datetime,
  DeletedAT datetime,
  Active bit not null
);

create table Feedback
(
  ID int identity(1,1),
  Name nvarchar(50) not null,
  Message nvarchar(1000) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key (ID)
)
;

create table [Log]
(
  ID int identity(1,1),
  [File] nvarchar(150) not null,
  [Function] nvarchar (150) not null,
  [Detail] nvarchar(MAX) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  primary key (ID)
);

create Table [Community(Audit)]
(
  ID int not null,
  Name nvarchar(50) not null,
  Type nvarchar(50) not null,
  Image varbinary(MAX) not null,
  ID_Up int,
  Name_Up nvarchar(50),
  Type_Up nvarchar(50),
  Image_Up varbinary(MAX),
  CreatedAT datetime not null,
  UpdatedAT datetime,
  DeletedAT datetime,
  Active bit not null,
);
create table Reviews
(
  ID int identity(1,1),
  StudentID int not null,
  TeacherID int not null,
  Rating int not null,
  Message nvarchar(1000) not null,
  CreatedAT datetime not null,
  UpdatedAT datetime not null,
  Active bit not null,
  foreign key (TeacherID) references Community(ID),
  foreign key (StudentID) references Community(ID)
)


--============================================ Audit table triggers ============================================================

--============================================ Community Table Trigger =========================================================
go
CREATE TRIGGER trg_Community_Audit
ON Community
AFTER DELETE, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO [Community(Audit)] (ID, Name, Type, Image, ID_Up, Name_Up, Type_Up, Image_Up, CreatedAT, UpdatedAT, DeletedAT, Active)
        SELECT d.ID, d.Name, d.Type, d.Image, i.ID, i.Name, i.Type, i.Image, d.CreatedAT, d.UpdatedAT, GETDATE(), d.Active
        FROM deleted d
        LEFT JOIN inserted i ON d.ID = i.ID
    END
END
GO

--============================================ Payment Table Trigger =========================================================
CREATE TRIGGER trg_Payments_Audit
ON Payments
AFTER DELETE, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO [Payments(Audit)] (ID, StudentID, TeacherID, BookingID, Amount, PaymentMethod, Status, ID_Up, StudentID_Up, TeacherID_Up, BookingID_Up, Amount_Up, PaymentMethod_Up, Status_Up, CreatedAT, UpdatedAT, DeletedAT, Active)
        SELECT d.ID, d.StudentID, d.TeacherID, d.BookingID, d.Amount, d.PaymentMethod, d.Status, i.ID, i.StudentID, i.TeacherID, i.BookingID, i.Amount, i.PaymentMethod, i.Status, d.CreatedAT, d.UpdatedAT, GETDATE(), '0'
        FROM deleted d
        LEFT JOIN inserted i ON d.ID = i.ID
    END
END
GO

--============================================ Credentials Table Trigger =========================================================
CREATE TRIGGER trg_Credential_Audit
ON Credential
AFTER DELETE, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO [Credentials(Audit)] (ID, Email, Password, ID_Up, Email_Up, Password_Up, CreatedAT, UpdatedAT, DeletedAT, Active)
        SELECT d.ID, d.Email, d.Password, i.ID, i.Email, i.Password, d.CreatedAT, d.UpdatedAT, GETDATE(), '0'
        FROM deleted d
        LEFT JOIN inserted i ON d.ID = i.ID
    END
END
GO

--============================================ Conversation Table Trigger =========================================================
CREATE TRIGGER trg_Conversations_Audit
ON Conversations
AFTER DELETE, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO [Conversations(Audit)] (ConversationID, TeacherID, StudentID, LastChecked, ConversationID_Up, TeacherID_Up, StudentID_Up, LastChecked_Up, CreatedAT, UpdatedAT, DeletedAT, Active)
        SELECT d.ConversationID, d.TeacherID, d.StudentID, d.LastChecked, i.ConversationID, i.TeacherID, i.StudentID, i.LastChecked, d.CreatedAT, d.UpdatedAT, GETDATE(), '0'
        FROM deleted d
        LEFT JOIN inserted i ON d.ConversationID = i.ConversationID
    END
END
GO

--============================================ Message Table Trigger =========================================================
CREATE TRIGGER trg_Messages_Audit
ON Messages
AFTER DELETE, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO [Messages(Audit)] (ConversationID, Message, SenderID, CreatedAT, UpdatedAT, DeletedAT, Active, ConversationID_Up, Message_Up, SenderID_Up)
        SELECT d.ConversationID, d.Message, d.SenderID, d.CreatedAT, d.UpdatedAT, GETDATE(), d.Active, i.ConversationID, i.Message, i.SenderID
        FROM deleted d
        LEFT JOIN inserted i ON d.ConversationID = i.ConversationID
    END
END
GO



--============================================ Procedures ======================================================================
--============================================ Procedure 1 ======================================================================

go
create procedure sign_in
@username varchar(50),
@password varchar(50) 
AS
BEGIN
 Select * from Community c where ID=(Select ID from Credential cr where cr.Email=@username and cr.Password=@password)
END
go

--============================================ Procedure 2 ======================================================================
go
create procedure emailExists
@email varchar(50)
AS
BEGIN
 Select Email from Credential where Email=@email;
END
go

--============================================ Procedure 3 ======================================================================
go
create procedure sign_up_teacher
@name nvarchar(50),
@qualification nvarchar(250),
@expertise nvarchar(250),
@hourlyrate int,
@availability nvarchar(250),
@location nvarchar(150),
@email nvarchar(50),
@password nvarchar(50),
@img varbinary(max)
as
begin
 insert into Community (Name,Type,CreatedAT,UpdatedAT,Active,Image) values (@name,'Teacher',GETDATE(),GETDATE(),1,@img)
 DECLARE @CommunityID INT;
 SET @CommunityID = SCOPE_IDENTITY();
 INSERT INTO Credential (ID, Email, Password, CreatedAT, UpdatedAT, Active)
 VALUES (@CommunityID,@email,@password, GETDATE(), GETDATE(), 1);
 insert into Teachers (Active,Availability,CreatedAT,Expertise,HourlyRate,Location,Qualification,TeacherID,UpdatedAT) values (1,@availability,GETDATE(),@expertise,@hourlyrate,@location,@qualification,@CommunityID,GETDATE())
end
go

--============================================ Procedure 4 ======================================================================
go
create procedure sign_up_student
@name nvarchar(50),
@class nvarchar(250),
@subjects nvarchar(250),
@password nvarchar(50),
@email nvarchar(50),
@img varbinary(max)
as 
begin
  insert into Community (Name,Type,CreatedAT,UpdatedAT,Active,Image) values (@name,'Student',GETDATE(),GETDATE(),1,@img)
  DECLARE @CommunityID INT;
  SET @CommunityID = SCOPE_IDENTITY();
  INSERT INTO Credential (ID, Email, Password, CreatedAT, UpdatedAT, Active)
  VALUES (@CommunityID,@email,@password, GETDATE(), GETDATE(), 1);
  insert into Students (Active,Class,CreatedAT,StudentID,Subjects,UpdatedAT) values (1,@class,GETDATE(),@CommunityID,@subjects,GETDATE())
end
go

--============================================ Procedure 5 ======================================================================

CREATE PROCEDURE find_teachers_advance
    @Name NVARCHAR(50) = NULL,
    @Qualification NVARCHAR(100) = NULL,
    @Expertise NVARCHAR(100) = NULL,
    @Availability NVARCHAR(100) = NULL,
    @Location NVARCHAR(100) = NULL,
    @HourlyRate DECIMAL(10, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.Name,
        s.Qualification,
        s.Expertise,
        s.Availability,
        s.Location,
        s.HourlyRate,
		s.ID,
        s.Image,
        (
            CASE WHEN Name = @Name THEN 1 ELSE 0 END +
            CASE WHEN Qualification = @Qualification THEN 3 ELSE 0 END +
            CASE WHEN Expertise = @Expertise THEN 3 ELSE 0 END +
            CASE WHEN Availability = @Availability THEN 3 ELSE 0 END +
            CASE WHEN Location = @Location THEN 3 ELSE 0 END +
            CASE WHEN HourlyRate <= @HourlyRate THEN 3 ELSE 0 END +
            CASE WHEN @Name IS NULL OR Name LIKE '%' + ISNULL(@Name, '') + '%' THEN 1 ELSE 0 END +
            CASE WHEN @Qualification IS NULL OR Qualification LIKE '%' + ISNULL(@Qualification, '') + '%' THEN 1 ELSE 0 END +
            CASE WHEN @Expertise IS NULL OR Expertise LIKE '%' + ISNULL(@Expertise, '') + '%' THEN 1 ELSE 0 END +
            CASE WHEN @Availability IS NULL OR Availability LIKE '%' + ISNULL(@Availability, '') + '%' THEN 1 ELSE 0 END +
            CASE WHEN @Location IS NULL OR Location LIKE '%' + ISNULL(@Location, '') + '%' THEN 1 ELSE 0 END +
            CASE WHEN @HourlyRate IS NULL OR HourlyRate <= @HourlyRate THEN 1 ELSE 0 END
        ) AS MatchScore
    FROM
        (
            SELECT
                Name, Qualification, Expertise, Availability, Location, HourlyRate, Image,ID
            FROM
                Community c
            JOIN
                Teachers t ON c.ID = t.TeacherID
            WHERE
                (@Name IS NULL OR Name LIKE '%' + ISNULL(@Name, '') + '%') AND
                (@Qualification IS NULL OR Qualification LIKE '%' + ISNULL(@Qualification, '') + '%') AND
                (@Expertise IS NULL OR Expertise LIKE '%' + ISNULL(@Expertise, '') + '%') AND
                (@Availability IS NULL OR Availability LIKE '%' + ISNULL(@Availability, '') + '%') AND
                (@Location IS NULL OR Location LIKE '%' + ISNULL(@Location, '') + '%') AND
                (@HourlyRate IS NULL OR HourlyRate <= @HourlyRate)
        ) AS s
    ORDER BY
        MatchScore DESC;
END;
go
--============================================ Procedure 6 ======================================================================
create procedure find_teachers
@Expertise nvarchar(100)
as
begin
  Select * from (Community c join Teachers t on c.ID=t.TeacherID) where t.Expertise like '%'+@Expertise+'%'
end
go
--============================================ Procedure 7 ======================================================================
create procedure student_enroll
@Stu_id int,
@Tea_id int,
@Subject nvarchar(100),
@Date datetime,
@Starttime nvarchar(50),
@Endtime nvarchar(50)
as
begin
  Insert into Bookings (Active,CreatedAT,UpdatedAT,TeacherID,StudentID,Date,Subject,StartTime,EndTime,Status) values('1',GETDATE(),GETDATE(),@Tea_id,@Stu_id,@Date,@Subject,@Starttime,@Endtime,'Pending');
  Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),'New Student Send Enrollment request.','0',GETDATE(),@Tea_id);
end
go

--============================================ Procedure 8 ======================================================================
create procedure see_enrollments
@tea_id int
as
begin 
Select * from Bookings where Status='Pending' and TeacherID=@tea_id;
end
go
--============================================ Procedure 9 ======================================================================
create procedure accept_enrollment 
@id int
as
begin
   DECLARE @time1 NVARCHAR(10) = (Select EndTime from Bookings where ID=@id);
   DECLARE @time2 NVARCHAR(10) = (Select StartTime from Bookings where ID=@id);

   declare @convertedTime1 time = CONVERT(TIME, @time1)
   declare @convertedTime2 time = CONVERT(TIME, @time2)
   declare @difference int = DATEDIFF(HOUR, @convertedTime2, @convertedTime1)
   declare @price int =@difference*(Select HourlyRate from Teachers where TeacherID=(Select TeacherID from Bookings where ID=@id));
   Insert into Payments(Active,Amount,BookingID,CreatedAT,PaymentMethod,Status,StudentID,TeacherID,UpdatedAT) values ('1',@price,@id,GETDATE(),null,'UNPAID',(Select StudentID from Bookings where ID=@id),(Select TeacherID from Bookings where ID=@id),GETDATE());
   Update Bookings set Status='Accept' where ID=@id; 
   Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),(Select Name from Community where ID=(Select TeacherID from Bookings where ID=@id))+' accepted your enrollment request','0',GETDATE(),(Select StudentID from Bookings where ID=@id));
end
go
--============================================ Procedure 10 ======================================================================
create procedure decline_enrollment 
@id int
as
begin
   Delete from Bookings where ID=@id; 
   Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),(Select Name from Community where ID=(Select TeacherID from Bookings where ID=@id))+' declined your enrollment request','0',GETDATE(),(Select StudentID from Bookings where ID=@id));
end
go
--============================================ Procedure 11 ======================================================================
create procedure add_assignment 
@enrollment_id int,
@assignment_title nvarchar(500),
@assignment_description nvarchar(1000)
as
begin
   declare @stu_id int=(Select StudentID from Bookings where ID=@enrollment_id);
   declare @tea_id int=(Select TeacherID from Bookings where ID=@enrollment_id);
   Insert into Assessment (Active,Assignment,CreatedAT,StudentID,TeacherID,Title,UpdatedAT) values ('1',@assignment_description,GETDATE(),@stu_id,@tea_id,@assignment_title,GETDATE());
   Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),'A new assignment has been added.','0',GETDATE(),@stu_id);
end
go
--============================================ Procedure 12 ======================================================================
create procedure is_booked
@book_id int
as
begin
 Select * from Bookings where ID=@book_id;
end
go
--============================================ Procedure 13 ======================================================================
create procedure remove_assignment
@id int
as
begin
 Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),'An assignment has been removed.','0',GETDATE(),(Select StudentID from Assessment where ID=@id));
 delete from AssessmentSubmission where AssignmentID=@id;
 delete from Assessment where ID=@id;
end
go
----============================================ Procedure 14 ======================================================================
create procedure is_assignment_submitted
@id int
as
begin
Select * from AssessmentSubmission where AssignmentID=@id;
end
go
----============================================ Procedure 15 ======================================================================
create procedure upload_assignment
@assignment_id int,
@tea_id int,
@stu_id int,
@file_name nvarchar(500),
@file varbinary(MAX)
as
begin
 Insert into AssessmentSubmission (Active,AssignmentID,CreatedAT,[File],[Filename],StudentID,TeacherID,UpdatedAT) values ('1',@assignment_id,GETDATE(),@file,@file_name,@stu_id,@tea_id,GETDATE());
 insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),(Select name from Community where ID=@stu_id)+' added you in his conversations','0',GETDATE(),@tea_id);
end
go
----============================================ Procedure 16 ======================================================================
create procedure find_stu_assignments
@id int
as
begin
 Select ID,StudentID,TeacherID,Title,Assignment from Assessment where StudentID=@id;
end
go
----============================================ Procedure 17 ======================================================================
create procedure see_booked_students
@id int
as
begin
 Select * from Bookings where TeacherID=@id; 
end
go
----============================================ Procedure 18 ======================================================================
create procedure find_conversation
@stu_id int,
@tea_id int
as
begin
 Select * from Conversations where StudentID=@stu_id and TeacherID=@tea_id;
end
go
----============================================ Procedure 19 ======================================================================
create procedure add_conversation
@stu_id int,
@tea_id int
as
begin
 Insert into Conversations (Active,CreatedAT,StudentID,TeacherID,UpdatedAT,LastChecked) values ('1',GETDATE(),@stu_id,@tea_id,GETDATE(),GETDATE());
 insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),(Select name from Community where ID=@stu_id)+' added you in his conversations','0',GETDATE(),@tea_id);
end
go
----============================================ Procedure 20 ======================================================================
create procedure check_conversation_change
@c_id int
as
begin
 SELECT *
    FROM Messages m
    WHERE ConversationID=@c_id and CreatedAT>(Select LastChecked from Conversations where ConversationID=@c_id);
 Update Conversations set LastChecked=GETDATE() where ConversationID=@c_id;
end
go
----============================================ Procedure 21 ======================================================================
create procedure load_student_chats
@id int
as
begin
 Select * from Conversations cv join Community cm on cv.TeacherID=cm.ID where StudentID=@id;
end
go
----============================================ Procedure 22 ======================================================================
create procedure load_teacher_chats
@id int
as
begin
 Select * from Conversations cv join Community cm on cv.StudentID=cm.ID where TeacherID=@id;
end
go
----============================================ Procedure 23 ======================================================================
create procedure load_chats
@id int
as
begin
 Select * from Messages where ConversationID=@id;
end
go
----============================================ Procedure 24 ======================================================================
create procedure send_message
@c_id int,
@s_id int,
@message nvarchar(500)
as
begin
  Update Conversations set UpdatedAT=GETDATE() where ConversationID=@c_id;
  Insert into Messages (Active,ConversationID,CreatedAT,Message,SenderID,UpdatedAT) values ('1',@c_id,GETDATE(),@message,@s_id,GETDATE());
end
go
----============================================ Procedure 25 ======================================================================
create procedure see_teacher_payments
@t_id int
as
begin
  Select * from Payments where TeacherID=@t_id;
end
go
----============================================ Procedure 26 ======================================================================
create procedure see_student_payments
@s_id int
as
begin
  Select * from Payments where StudentID=@s_id;
end
go
----============================================ Procedure 27 ======================================================================
create procedure send_fee_notification
@pay_id int
as
begin
  declare @message nvarchar(max) ='Please submit payment corresponding to ID '+convert(nvarchar(max),@pay_id)+'.';
  declare @stu_id int=(Select StudentID from Payments where ID=@pay_id);
  Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),@message,'0',GETDATE(),@stu_id);
end
go
----============================================ Procedure 28 ======================================================================
create procedure remove_fee
@pay_id int
as
begin
  delete from Payments where ID=@pay_id;
  declare @student_id int=(Select StudentID from Payments where ID=@pay_id);
  insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values('1',GETDATE(),'A payment has been removed by a teacher.','0',GETDATE(),@student_id);
end
go
----============================================ Procedure 29 ======================================================================
create procedure verify_payment
@pay_id int
as
begin
  update Payments set PaymentMethod='Verified By Teacher',Status='PAID' where ID=@pay_id;
  declare @student_id int=(Select StudentID from Payments where ID=@pay_id);
  insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values('1',GETDATE(),'One of your fee have been verified.','0',GETDATE(),@student_id);
end
go
----============================================ Procedure 30 ======================================================================
create procedure send_fee_notification_student
@pay_id int
as
begin
  declare @message nvarchar(max) ='Dear Sir, I want you to verify fee against ID : '+convert(nvarchar(max),@pay_id)+'.';
  declare @tea_id int=(Select TeacherID from Payments where ID=@pay_id);
  Insert into Notification (Active,CreatedAT,Message,Seen,UpdatedAT,UserID) values ('1',GETDATE(),@message,'0',GETDATE(),@tea_id);
end
go
----============================================ Procedure 31 ======================================================================
create procedure load_review
@t_id int
as
begin
  Select Name,Image,Message,Rating from (Reviews r join Community c on r.StudentID=c.ID) where r.TeacherID=@t_id;
end
go
----============================================ Procedure 32 ======================================================================
create procedure add_review
@t_id int,
@s_id int,
@message nvarchar(1000),
@rating int
as
begin
  Insert into Reviews (Active,CreatedAT,Message,Rating,StudentID,TeacherID,UpdatedAT) values('1',getdate(),@message,@rating,@s_id,@t_id,GETDATE());
end
go
----============================================ Procedure 33 ======================================================================
create procedure get_avg_teacher_rating
@t_id int
as
begin
  Select AVG(Rating) as AvgValue from Reviews where TeacherID=@t_id;
end
go
----============================================ Procedure 35 ======================================================================
create procedure load_feedback
as
begin
  Select * from Feedback
end
go
----============================================ Procedure 36 ======================================================================
create procedure add_feedback
@name nvarchar(50),
@message nvarchar(1000)
as
begin
  Insert into Feedback(Active,CreatedAT,Message,Name,UpdatedAT) values ('1',GETDATE(),@message,@name,GETDATE());
end
go
--============================================== procedure 37 ======================================================================
create procedure get_progress
@stu_id int
as
begin
 SELECT
    (SELECT COUNT(Assignment) FROM Assessment WHERE StudentID = @stu_id) AS TotalAssignments,
    (SELECT COUNT(StudentID) FROM AssessmentSubmission WHERE StudentID = @stu_id) AS SubmittedAssignments,
    (SELECT COUNT(Status) FROM Payments WHERE StudentID = @stu_id) AS TotalPayments,
    (SELECT COUNT(Status) FROM Payments WHERE StudentID = @stu_id AND Status = 'PAID') AS PaidPayments;
end
go
--============================================== procedure 38 ======================================================================
create procedure get_notifications
@id int
as
begin
 select * from Notification where UserID=@id;
 update Notification set Seen='1' where UserID=@id;
end
go
--============================================== procedure 39 ======================================================================
create procedure remove_notification
@id int
as
begin
 delete from Notification where ID=@id;
end
go
--============================================== procedure 40 ======================================================================
create procedure remove_all_notification
@id int
as
begin
 delete from Notification where UserID=@id;
end
go
--============================================== procedure 41 ======================================================================
create procedure update_teacher
@t_id int,
@name nvarchar(50),
@qualification nvarchar(150),
@expertise nvarchar(150),
@hourlyrate int,
@availability nvarchar(250),
@location nvarchar(250)
as
begin
 update Community set Name=@name,UpdatedAT=GETDATE() where ID=@t_id ;
 update Teachers set UpdatedAT=GETDATE(),Availability=@availability,Expertise=@expertise,HourlyRate=@hourlyrate,Location=@location,Qualification=@qualification where TeacherID=@t_id;
end
go
--============================================ Procedure 42 ======================================================================
go
create procedure update_student
@name nvarchar(50),
@class nvarchar(250),
@subjects nvarchar(250),
@s_id int
as 
begin
  update Community set Name=@name,UpdatedAT=GETDATE()where ID=@s_id;
  update Students set Class=@class,Subjects=@subjects,UpdatedAT=GETDATE() where StudentID=@s_id;
end
go
--============================================ Procedure 43 ======================================================================
go
create procedure report_error
@file nvarchar(150),
@function nvarchar(150),
@message nvarchar(max)
as 
begin
  insert into Log (Active,CreatedAT,Detail,[File],[Function],UpdatedAT) values ('1',GETDATE(),@message,@file,@function,GETDATE());
end
go
--============================================ Procedure 44 ======================================================================
go
create procedure return_favourite_students
@t_id int
as 
begin
  Select StudentID,Name  from Favourites f join Community c on f.StudentID=c.ID; 
end
go
--============================================ Procedure 45 ======================================================================
go
create procedure add_favourite_students
@t_id int,
@s_id int
as 
begin
  insert into Favourites(Active,CreatedAT,StudentID,TeacherID,UpdatedAT) values ('1',GETDATE(),@s_id,@t_id,GETDATE());
end
go
--============================================ Procedure 46 ======================================================================
go
create procedure is_student_already_favourite
@t_id int,
@s_id int
as 
begin
  Select * from Favourites where TeacherID=@t_id and StudentID=@s_id; 
end
go
--============================================ Procedure 47 ======================================================================
go
create procedure remove_favourite_student
@t_id int,
@s_id int
as 
begin
  delete from Favourites where TeacherID=@t_id and StudentID=@s_id;
end
go
--============================================ Procedure 48 ======================================================================
go
create procedure load_teacher_assignments
@id int
as 
begin
  Select ID,Title,Assignment,StudentID from Assessment where TeacherID=@id;
end
go
--============================================ Procedure 49 ======================================================================
create procedure see_accepted_enrollments
@tea_id int
as
begin 
Select * from Bookings where Status='Accept' and TeacherID=@tea_id;
end
go
