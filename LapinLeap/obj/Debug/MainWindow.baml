   M S B A M L   `   `   `  ����D  @LapinLeap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LapinLeap	LapinLeap  5   	       LapinLeap.MainWindow   %	LapinLeapclr-namespace:LapinLeap  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   e aMicrosoft.Surface.Presentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e356Custom)http://schemas.microsoft.com/surface/2008  5   	   -   5          � Title$  	LapinLeap��5   	   $	��600��6   $
��1018��6(   .��5      �  � ColumnDefinitions 5	   
   �� 5
      .+�5   
   � -   5         �Name$ bgGrid��5      ���	#FF1A2951$��
0,-1,0,-11q�66      LapinLeap.GameGrid  5   
   -   5          Name$
 game��5      $��242,21,22,10q�6+      LapinLeap.Inventory  5   
   -   5          Name$ 	inventory��5      $
��Left=�61   $��
21,21,0,10q�6L   $
��Auto��6`   $	��211��6n   � 5   
   $��33,33,790,91q�6    J� IsHitTestVisible .  .+�5         LapinLeap.avatar  -   5          Name$ avatar��5       .  6/   5      �� 5   
   -   5         ��Name$ DoomsdayClock��5      
�������$��	0,-13,0,0q�6;   $��Franklin Gothic Heavy)�6N   $��50(�6q   $	��110��6   $	��Top=�6�   $��Right=�6�   $	��155��6�   $��00:00��6�   �� 5   
   -   5         ��Name$ 	MapCanvas��5      ���	#801A2951$��21,21,22,10q�6<   $y�	Collapsed=�6Q   .+�5         LapinLeap.map  6   5      �� 5   
   -   5        $ pulser��5      $��	0,-13,0,0q�6"   $��Franklin Gothic Heavy)�65   $��50(�6X   $	��110��6f   $	��Top=�6s   $��Right=�6�   $	��989��6�   $��you dropped something��6�   ���	#00000000$
��Left=�6�    .  6  �� 5   
   -	   5        $ PhoneCanvas��5      ���	#801A2951$��21,21,22,10q�6>   $y�Hidden=�6�      LapinLeap.phone  5   
   -
   5        	  Name$
	 cell��5      $y�Hidden=�6(   $��242,165,505,26q�6<   5      5      