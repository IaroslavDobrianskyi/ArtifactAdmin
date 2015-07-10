SELECT * FROM information_schema.tables

declare @id int, @stuff nvarchar(100), @tablename nvarchar(150)
declare @tmp table
(
  id int not null
, stuff nvarchar(100)

  primary key(id)
)

insert @tmp
select ROW_NUMBER() Over (ORDER BY TABLE_NAME DESC  ) as id, TABLE_NAME from information_schema.tables

select top 1 @id=id, @stuff=stuff from @tmp

while (@@rowcount > 0)
begin
  set @tablename = @stuff + '.id'
  EXEC sp_rename @tablename, 'Id', 'Column';
  delete from @tmp where id=@id
  select top 1 @id=id, @stuff=stuff from @tmp
end