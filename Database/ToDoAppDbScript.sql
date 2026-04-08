create database ToDoDb

create table ToDoItem
(
Id int identity(1,1) primary key, 
Description nvarchar(max) not null,
CreatedAt Datetime default getdate(),
UpdatedAt Datetime null,
IsDone bit default 0
)

insert into ToDoItem (Description)
values ('Eat'), ('Feed the dog')

select * from ToDoItem