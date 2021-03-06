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
SET IDENTITY_INSERT [dbo].[Desire] ON 
delete from Desire
INSERT [dbo].[Desire] ([Id], [Name], [Description], [Icon]) VALUES (1, N'Їсти', N'Їсти', N'dbbcbaaf-c056-41e7-bd9f-854b81581d19_asc.png')
INSERT [dbo].[Desire] ([Id], [Name], [Description], [Icon]) VALUES (2, N'спати', N'спати', N'1c2b795b-0662-40ef-b13a-0063a8d1fcf3_bg.png')
INSERT [dbo].[Desire] ([Id], [Name], [Description], [Icon]) VALUES (3, N'ставати сильнішим', N'ставати сильнішим', N'675ae35d-143e-4cd2-81a9-c9bb6e91b869_desc.png')
INSERT [dbo].[Desire] ([Id], [Name], [Description], [Icon]) VALUES (4, N'збирати реліквії, артефакти', N'збирати реліквії, артефакти', N'9f411ed6-9f75-4130-a527-1f8b112a2235_desc.png')
INSERT [dbo].[Desire] ([Id], [Name], [Description], [Icon]) VALUES (5, N'Шукати скарб', N'Шукати скарб', N'ead5a19c-1ffc-47ec-9ca4-0574a9a5ea6e_prev.png')
SET IDENTITY_INSERT [dbo].[Desire] OFF
SET IDENTITY_INSERT [dbo].[RaceDesire] ON 
delete from RaceDesire
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (2, 3, 2, 0.25, 20, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (3, 3, 1, 0.25, 10, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (4, 3, 3, 0.5, 60, 10)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (5, 3, 4, 0.5, 50, 5)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (6, 4, 1, 0.5, 50, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (7, 4, 2, 0.5, 100, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (8, 2, 1, 0.3, 100, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (9, 2, 2, 0.3, 100, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (10, 2, 3, 0.5, 50, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (11, 1, 1, 0.25, 20, NULL)
INSERT [dbo].[RaceDesire] ([Id], [RaceId], [DesireId], [Probability], [DefaultValue], [Deviation]) VALUES (12, 1, 2, 0.25, 20, NULL)
SET IDENTITY_INSERT [dbo].[RaceDesire] OFF
SET IDENTITY_INSERT [dbo].[MapZone] ON 
delete from MapZone
INSERT [dbo].[MapZone] ([Id], [ZoneName], [Color]) VALUES (1, N'Болото                                            ', N'#808000   ')
INSERT [dbo].[MapZone] ([Id], [ZoneName], [Color]) VALUES (2, N'Ліс                                               ', N'#008000   ')
SET IDENTITY_INSERT [dbo].[MapZone] OFF
SET IDENTITY_INSERT [dbo].[DesireMapZone] ON 
delete from DesireMapZone
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (1, 1, 1, 0.7)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (2, 2, 1, 0.8)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (3, 3, 1, 0.5)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (4, 4, 1, 0.9)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (5, 5, 1, 0.2)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (6, 1, 2, 0.5)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (7, 2, 2, 0.5)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (8, 3, 2, 0.5)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (9, 4, 2, 0.8)
INSERT [dbo].[DesireMapZone] ([Id], [Desire], [MapZone], [Modifier]) VALUES (10, 5, 2, 0.5)
SET IDENTITY_INSERT [dbo].[DesireMapZone] OFF
SET IDENTITY_INSERT [dbo].[StepObjectType] ON 
delete from StepObjectType
INSERT [dbo].[StepObjectType] ([Id], [Name]) VALUES (1, N'Живі Істоти')
SET IDENTITY_INSERT [dbo].[StepObjectType] OFF
SET IDENTITY_INSERT [dbo].[StepObject] ON 
delete from StepObject
INSERT [dbo].[StepObject] ([Id], [StepObjectType], [Name], [Description], [Icon]) VALUES (1, 1, N'Кінь', N'кіііііінь', N'614fbbfd-ea69-421f-b861-fd595af6073e_IMG_1775.JPG')
INSERT [dbo].[StepObject] ([Id], [StepObjectType], [Name], [Description], [Icon]) VALUES (2, 1, N'Собака', N'СОБААААААКа
', N'f2d8cf47-bd80-4324-a3e4-0772e08258d2_IMG_1793.JPG')
SET IDENTITY_INSERT [dbo].[StepObject] OFF
SET IDENTITY_INSERT [dbo].[MapObject] ON 
delete from MapObject
INSERT [dbo].[MapObject] ([Id], [Name]) VALUES (1, N'Дерево                                            ')
INSERT [dbo].[MapObject] ([Id], [Name]) VALUES (2, N'Печера                                            ')
INSERT [dbo].[MapObject] ([Id], [Name]) VALUES (3, N'Острів                                            ')
SET IDENTITY_INSERT [dbo].[MapObject] OFF
SET IDENTITY_INSERT [dbo].[MapObjectProbability] ON 
delete from MapObjectProbability
INSERT [dbo].[MapObjectProbability] ([Id], [MapObject], [MapZone], [Probability]) VALUES (5, 1, 2, 0.99)
INSERT [dbo].[MapObjectProbability] ([Id], [MapObject], [MapZone], [Probability]) VALUES (6, 2, 2, 0.5)
INSERT [dbo].[MapObjectProbability] ([Id], [MapObject], [MapZone], [Probability]) VALUES (7, 1, 1, 0.25)
INSERT [dbo].[MapObjectProbability] ([Id], [MapObject], [MapZone], [Probability]) VALUES (8, 3, 1, 0.2)
SET IDENTITY_INSERT [dbo].[MapObjectProbability] OFF
SET IDENTITY_INSERT [dbo].[ActionTemplateResult] ON 
delete from ActionTemplateResult
INSERT [dbo].[ActionTemplateResult] ([Id], [PredispositionResultModifier], [ExperienceModifier], [ArtifactPosibility], [GoldModifier], [QuestTemplate]) VALUES (1, 0.1, 0.2, 0.3, 0.4, NULL)
INSERT [dbo].[ActionTemplateResult] ([Id], [PredispositionResultModifier], [ExperienceModifier], [ArtifactPosibility], [GoldModifier], [QuestTemplate]) VALUES (2, 0, 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[ActionTemplateResult] OFF
SET IDENTITY_INSERT [dbo].[ActionTemplate] ON 
delete from ActionTemplate
INSERT [dbo].[ActionTemplate] ([Id], [Name], [BlockProbability], [ActionTemplateResult]) VALUES (1, N'збирати ягоди', 0.35, 1)
INSERT [dbo].[ActionTemplate] ([Id], [Name], [BlockProbability], [ActionTemplateResult]) VALUES (2, N'Полювати', 0.25, 2)
INSERT [dbo].[ActionTemplate] ([Id], [Name], [BlockProbability], [ActionTemplateResult]) VALUES (3, N'обдумати стратегію і вступити в бій', 0.25, 1)
SET IDENTITY_INSERT [dbo].[ActionTemplate] OFF
SET IDENTITY_INSERT [dbo].[StepTemplate] ON 
delete from StepTemplate
INSERT [dbo].[StepTemplate] ([Id], [Description], [StepText], [Name], [Desire], [IsNotVisibleInFlow], [IsQuestStarter]) VALUES (1, N'Перемогти ворога', N'Перемогти ворога', N'Перемогти ворога', NULL, 0, 0)
INSERT [dbo].[StepTemplate] ([Id], [Description], [StepText], [Name], [Desire], [IsNotVisibleInFlow], [IsQuestStarter]) VALUES (2, N'Добувати їжу', N'Добувати їжу', N'Добувати їжу', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[StepTemplate] OFF
SET IDENTITY_INSERT [dbo].[StepTemplateActionTemplate] ON 
delete from StepTemplateActionTemplate
INSERT [dbo].[StepTemplateActionTemplate] ([Id], [StepTemplate], [ActionTemplate]) VALUES (1, 2, 2)
INSERT [dbo].[StepTemplateActionTemplate] ([Id], [StepTemplate], [ActionTemplate]) VALUES (2, 2, 1)
INSERT [dbo].[StepTemplateActionTemplate] ([Id], [StepTemplate], [ActionTemplate]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[StepTemplateActionTemplate] OFF
SET IDENTITY_INSERT [dbo].[Class] ON 
delete from Class
INSERT [dbo].[Class] ([Id], [Description], [Icon], [FibonacciSeed]) VALUES (1, N'воїн', N'f5398d64-d14f-439c-9ea4-526eb2ef23c1_desc.png', 5)
INSERT [dbo].[Class] ([Id], [Description], [Icon], [FibonacciSeed]) VALUES (2, N'лучник', N'd543170f-a76a-49b2-93c9-57785f5da5cb_desc.png', 3)
INSERT [dbo].[Class] ([Id], [Description], [Icon], [FibonacciSeed]) VALUES (3, N'маг', N'fbd69531-7400-4f45-8c06-f8802ed79ac9_asc.png', 8)
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[ActionDescription] ON 
delete from ActionDescription
INSERT [dbo].[ActionDescription] ([Id], [ActionTemplate], [MapZone], [ActionText], [Race], [Class]) VALUES (1, 1, 1, N'збирати журавлину в кошики', 3, 1)
INSERT [dbo].[ActionDescription] ([Id], [ActionTemplate], [MapZone], [ActionText], [Race], [Class]) VALUES (2, 1, 2, N'нарубати гілки кущів вовчих ягід', 2, 1)
INSERT [dbo].[ActionDescription] ([Id], [ActionTemplate], [MapZone], [ActionText], [Race], [Class]) VALUES (3, 2, 1, N'полювати на бегемотів з допомогою міцної сітки', 1, 1)
INSERT [dbo].[ActionDescription] ([Id], [ActionTemplate], [MapZone], [ActionText], [Race], [Class]) VALUES (4, 2, 2, N'полювати на оленів з засідки за допомогою лука та стріл', 3, 2)
SET IDENTITY_INSERT [dbo].[ActionDescription] OFF
SET IDENTITY_INSERT [dbo].[Talent] ON 
delete from Talent
INSERT [dbo].[Talent] ([Id], [Description], [Name], [MaxLevel], [Modifier], [BaseValue], [BaseModifier], [Icon]) VALUES (1, N'здатність не забувати місію при смерті керіора ', N'здатність не забувати місію при смерті керіора ', 1, 0.2, 0.1, 0.3, N'c829da91-0a4e-425c-b433-68b5cd2e7b1e_asc.png')
INSERT [dbo].[Talent] ([Id], [Description], [Name], [MaxLevel], [Modifier], [BaseValue], [BaseModifier], [Icon]) VALUES (2, N'Здатність що зменшує частоту появи блокуючих дій', N'Здатність що зменшує частоту появи блокуючих дій', 6, 0.5, 0.2, 0.6, N'26d259d5-ec41-4815-9da7-f58ccefd8c5c_bg.png')
SET IDENTITY_INSERT [dbo].[Talent] OFF
SET IDENTITY_INSERT [dbo].[QuestTemplate] ON 
delete from QuestTemplate
INSERT [dbo].[QuestTemplate] ([Id], [Name], [Description]) VALUES (2, N'квест2', N'квест2    ')
INSERT [dbo].[QuestTemplate] ([Id], [Name], [Description]) VALUES (3, N'квест1', N'квест1    ')
SET IDENTITY_INSERT [dbo].[QuestTemplate] OFF
SET IDENTITY_INSERT [dbo].[QuestTemplateStepTemplate] ON 
delete from QuestTemplateStepTemplate
INSERT [dbo].[QuestTemplateStepTemplate] ([Id], [StepTemplate], [QuestTemaplate], [StepOrder]) VALUES (3, 1, 2, 1)
INSERT [dbo].[QuestTemplateStepTemplate] ([Id], [StepTemplate], [QuestTemaplate], [StepOrder]) VALUES (4, 2, 2, 2)
INSERT [dbo].[QuestTemplateStepTemplate] ([Id], [StepTemplate], [QuestTemaplate], [StepOrder]) VALUES (7, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[QuestTemplateStepTemplate] OFF
SET IDENTITY_INSERT [dbo].[DesireActionTemplateResult] ON 
delete from DesireActionTemplateResult
INSERT [dbo].[DesireActionTemplateResult] ([Id], [Desire], [ActionTemplateResult], [Modifier]) VALUES (3, 1, 1, 0.5)
INSERT [dbo].[DesireActionTemplateResult] ([Id], [Desire], [ActionTemplateResult], [Modifier]) VALUES (4, 3, 1, 0.9)
SET IDENTITY_INSERT [dbo].[DesireActionTemplateResult] OFF
SET IDENTITY_INSERT [dbo].[ActionTemplateCharacteristics] ON 
delete from ActionTemplateCharacteristics
INSERT [dbo].[ActionTemplateCharacteristics] ([Id], [ActionTemplate], [Characteristics]) VALUES (1, 1, 3)
INSERT [dbo].[ActionTemplateCharacteristics] ([Id], [ActionTemplate], [Characteristics]) VALUES (2, 3, 1)
INSERT [dbo].[ActionTemplateCharacteristics] ([Id], [ActionTemplate], [Characteristics]) VALUES (3, 3, 5)
INSERT [dbo].[ActionTemplateCharacteristics] ([Id], [ActionTemplate], [Characteristics]) VALUES (4, 2, 3)
SET IDENTITY_INSERT [dbo].[ActionTemplateCharacteristics] OFF
SET IDENTITY_INSERT [dbo].[ActionTemplatePredisposition] ON 
delete from ActionTemplatePredisposition
INSERT [dbo].[ActionTemplatePredisposition] ([Id], [ActionTemplate], [Predisposition], [RequirementLow], [RequirementHigh]) VALUES (1, 1, 2, 1, 7)
INSERT [dbo].[ActionTemplatePredisposition] ([Id], [ActionTemplate], [Predisposition], [RequirementLow], [RequirementHigh]) VALUES (2, 3, 3, 6, 10)
INSERT [dbo].[ActionTemplatePredisposition] ([Id], [ActionTemplate], [Predisposition], [RequirementLow], [RequirementHigh]) VALUES (3, 2, 1, 1, 5)
SET IDENTITY_INSERT [dbo].[ActionTemplatePredisposition] OFF
SET IDENTITY_INSERT [dbo].[ActionTemplateProperties] ON 
delete from ActionTemplateProperties
INSERT [dbo].[ActionTemplateProperties] ([Id], [ActionTemplate], [Properties], [Appearance]) VALUES (1, 1, 6, 1)
INSERT [dbo].[ActionTemplateProperties] ([Id], [ActionTemplate], [Properties], [Appearance]) VALUES (2, 3, 1, 1)
INSERT [dbo].[ActionTemplateProperties] ([Id], [ActionTemplate], [Properties], [Appearance]) VALUES (3, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[ActionTemplateProperties] OFF



