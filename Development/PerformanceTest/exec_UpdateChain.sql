USE [art]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[UpdateChain]
		@idU = 1,
		@kStep = 10,
		@kAct = 5,
		@NStep = 5,
		@NAct = 121

SELECT	'Return Value' = @return_value

GO
