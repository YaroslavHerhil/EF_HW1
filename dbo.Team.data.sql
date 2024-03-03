SET IDENTITY_INSERT [dbo].[Team] ON
INSERT INTO [dbo].[Team] ([ID], [TeamName], [TeamRegion], [Wins], [Loses], [Draws], [Goals], [MissedGoals]) VALUES (1, N'Team', N'Region1', 2, 4, 1, 12, 32)
INSERT INTO [dbo].[Team] ([ID], [TeamName], [TeamRegion], [Wins], [Loses], [Draws], [Goals], [MissedGoals]) VALUES (2, N'Team2', N'Region2', 4, 3, 5, 7, 42)
INSERT INTO [dbo].[Team] ([ID], [TeamName], [TeamRegion], [Wins], [Loses], [Draws], [Goals], [MissedGoals]) VALUES (4, N'Boccia', N'Regi3', 4, 3, 2, 42, 12)
INSERT INTO [dbo].[Team] ([ID], [TeamName], [TeamRegion], [Wins], [Loses], [Draws], [Goals], [MissedGoals]) VALUES (5, N'TheRockia', N'Here', 7, 6, 5, 4, 3)
SET IDENTITY_INSERT [dbo].[Team] OFF
