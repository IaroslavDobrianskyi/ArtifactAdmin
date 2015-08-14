USE [art]
GO
SET IDENTITY_INSERT [dbo].[ArtifactType] ON 
delete from ArtifactType
INSERT [dbo].[ArtifactType] ([Id], [Name], [Icon], [Descrioption]) VALUES (7, N'Кільце', N'd103c8b0-4406-4a62-8a45-7d1b78b783b0_ring.jpg', N'Кільце                                            ')
SET IDENTITY_INSERT [dbo].[ArtifactType] OFF
SET IDENTITY_INSERT [dbo].[Bonus] ON 
delete from Bonus
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (3, N'клас воїна                                        ', N'клас воїна                                        ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (4, N'клас лучника                                      ', N'клас лучника                                      ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (5, N'клас мага                                         ', N'клас мага                                         ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (6, N'сила                                              ', N'сила                                              ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (7, N'рівень броні                                      ', N'рівень броні                                      ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (8, N'точність                                          ', N'точність                                          ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (9, N'спритність                                        ', N'спритність                                        ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (10, N'інтелект                                          ', N'інтелект                                          ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (11, N'знання суперника                                  ', N'знання суперника                                  ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (12, N'бажання заробляти гроші                           ', N'бажання заробляти гроші                           ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (13, N'бонус при торгівлі                                ', N'бонус при торгівлі                                ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (14, N'красномовність                                    ', N'красномовність                                    ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (15, N'краще подавляє опір керіора                       ', N'краще подавляє опір керіора                       ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (16, N'краща швидкість руху                              ', N'краща швидкість руху                              ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (17, N'більше місця в рюкзаку                            ', N'більше місця в рюкзаку                            ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (18, N'менше спить                                       ', N'менше спить                                       ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (19, N'радіус обзору                                     ', N'радіус обзору                                     ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (20, N'більше енергії в юара                             ', N'більше енергії в юара                             ')
INSERT [dbo].[Bonus] ([Id], [Name], [Description]) VALUES (21, N'більший окіл передбачення в юара                  ', N'більший окіл передбачення в юара                  ')
SET IDENTITY_INSERT [dbo].[Bonus] OFF
SET IDENTITY_INSERT [dbo].[Characteristics] ON 
delete from Characteristics
INSERT [dbo].[Characteristics] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (1, N'Сила', N'Сила', 1, 2, 0)
INSERT [dbo].[Characteristics] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (2, N'Рівень броні', N'Рівень броні', 1, 2, 2)
INSERT [dbo].[Characteristics] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (3, N'Спритність', N'Спритність', 1, 2, 4)
INSERT [dbo].[Characteristics] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (4, N'Точність', N'Точність', 1, 3, 7)
INSERT [dbo].[Characteristics] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (5, N'Інтелект', N'Інтелект', 1, 1, 6)
SET IDENTITY_INSERT [dbo].[Characteristics] OFF
SET IDENTITY_INSERT [dbo].[Constellation] ON 
delete from Constellation
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (7, N'Воїн                                              ', N'5bda9a50-b7f1-4203-9d73-bff712bfbec3_solg.jpg                                                                                                                                                                                                             ', N'Воїн                                              ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (8, N'Лучник                                            ', N'93e0dbf8-eb3d-42e1-b9c6-f160c8f85dec_arbalet.jpg                                                                                                                                                                                                          ', N'Лучник                                            ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (9, N'Маг                                               ', N'b291b15b-9f8c-4b09-b547-d013e585b274_mag.jpg                                                                                                                                                                                                              ', N'Маг                                               ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (10, N'Торговець                                         ', N'39b99ccf-799a-4934-809e-c8e29a8644ab_torg.jpg                                                                                                                                                                                                             ', N'Торговець                                         ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (11, N'Лідер                                             ', N'c24cc5ae-c1a1-431a-8bc0-a4dd48d54f8d_lider.jpg                                                                                                                                                                                                            ', N'Лідер                                             ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (12, N'Мандрівник                                        ', N'5f957314-5a4f-42fe-8097-15b2dcd1c22b_mandry.png                                                                                                                                                                                                           ', N'Мандрівник                                        ')
INSERT [dbo].[Constellation] ([Id], [Name], [Icon], [Description]) VALUES (13, N'Вчений                                            ', N'409b7c39-53c7-445c-9064-267fa7c26488_clever.png                                                                                                                                                                                                           ', N'Вчений                                            ')
SET IDENTITY_INSERT [dbo].[Constellation] OFF
SET IDENTITY_INSERT [dbo].[Predisposition] ON 
delete from Predisposition 
INSERT [dbo].[Predisposition] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (1, N'Злий', N'Злий', 1, 2, 0)
INSERT [dbo].[Predisposition] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (2, N'Поміркований', N'Поміркований', 1, 2, 2)
INSERT [dbo].[Predisposition] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (3, N'Сміливий', N'Сміливий', 1, 2, 4)
INSERT [dbo].[Predisposition] ([Id], [Name], [Description], [Mask], [Length], [Position]) VALUES (4, N'Красномовний', N'Красномовний', 1, 2, 6)
SET IDENTITY_INSERT [dbo].[Predisposition] OFF
SET IDENTITY_INSERT [dbo].[Properties] ON 
delete from Properties
INSERT [dbo].[Properties] ([Id], [Name], [Description], [Length], [Position], [Deviation]) VALUES (1, N'Розмір', N'Розмір', 3, 0, N'1')
INSERT [dbo].[Properties] ([Id], [Name], [Description], [Length], [Position], [Deviation]) VALUES (3, N'Вік', N'Вік', 4, 3, N'1')
INSERT [dbo].[Properties] ([Id], [Name], [Description], [Length], [Position], [Deviation]) VALUES (6, N'Кількість речей в рюкзаку', N'Кількість речей в рюкзаку', 2, 9, N'1')
INSERT [dbo].[Properties] ([Id], [Name], [Description], [Length], [Position], [Deviation]) VALUES (7, N'Швидкість руху', N'Швидкість руху', 2, 7, N'1')
SET IDENTITY_INSERT [dbo].[Properties] OFF
SET IDENTITY_INSERT [dbo].[Race] ON 
delete from Race
INSERT [dbo].[Race] ([Id], [Description], [Characreristics], [CharacteristicsLevelModifier], [Predisposition], [Properties], [Icon]) VALUES (1, N'Ящури', N'10  20', N'1', N'30  10', N'10     50', N'85475b17-ce6c-421c-ac97-f4b7bf3eb984_asc.png')
INSERT [dbo].[Race] ([Id], [Description], [Characreristics], [CharacteristicsLevelModifier], [Predisposition], [Properties], [Icon]) VALUES (2, N'Орки', N'15  10', N'1', N'155', N'   100 30', N'eaabfc8a-7e38-4b83-87c4-13ef25720a9e_bg.png')
INSERT [dbo].[Race] ([Id], [Description], [Characreristics], [CharacteristicsLevelModifier], [Predisposition], [Properties], [Icon]) VALUES (3, N'Гноми', N'8030', N'1', N'50  50', N'5      10', N'7f1b12dd-de43-493f-b83b-2181750a5049_desc.png')
INSERT [dbo].[Race] ([Id], [Description], [Characreristics], [CharacteristicsLevelModifier], [Predisposition], [Properties], [Icon]) VALUES (4, N'Огри', N'60  30', N'1', N'2020', N'       3010', N'5e656879-1b90-4854-8f61-17fce2394270_asc.png')
SET IDENTITY_INSERT [dbo].[Race] OFF
