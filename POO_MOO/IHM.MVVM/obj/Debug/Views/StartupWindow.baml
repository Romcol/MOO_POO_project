   M S B A M L   `   `   `  ����C  ?IHM.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:IHM.MVVMIHM.MVVM  5   	   > :dev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&clr-namespace:dev;assembly=devdev 5   	   "    IHM.MVVM.Views.StartupWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:IHM.MVVM     5   	   .Devclr-namespace:dev;assembly=dev     5   	     � Title$  
SmallWorld��5	   	   $	��563��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � ��5   
   �� 5       �� ImageSource$ bg.jpg��6    � 	Resources 5   
      IHM.MVVM.Converter   conv��%   &	          5      6   5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��
header.png��6   $	��400��6$   $��Center=�60   $��Center=�6M   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��20(�6   $
��Bold"�6#   $��Select map size:��65   	� 5      $��20(�6   $��Center=�6(   $��0,0,15,0q�6J   $
��Demo��6�    	� 	GroupName$ mapSize��6   d� 	IsChecked 6\   ��  �� Path$ map_type�	 �� 	Converter#	 [    dev.MapType
   Demo �� ConverterParameter# Z
  �� UpdateSourceTrigger$ PropertyChanged=�6  	� 5      $��20(�6   $��Center=�6(   $��0,0,15,0q�6J   $��Small��6�   $ mapSize��6   6\   �� $ map_type�#	 [     Small# Z $ PropertyChanged=�6  	� 5      $��20(�6   $��Center=�6(   $��0,0,15,0q�6J   $��Standard��6�   $ mapSize��6   6\   �� $ map_type�#	 [     Standard# Z $ PropertyChanged=�6  5       � 5!   
   $��2��6    � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $��* �6#   .+�5&      �� $��0��6   $ Vertical=�6)   $��10,0,0,0q�6@   .+�5'      �� $��20(�6   $
��Bold"�6'   $��	Player 1:��69   $��10,0,0,5q�6M   �� 5(      $��20(�6   $
��Bold"�6'   $��Name:��69   $��10,0,0,0q�6I   �� 5)      $��10,0,0,0q�6   $	��150��6D   $
��Left=�6P   ��6,   �� *p1Name+6P   �� 5*      $��20(�6   $
��Bold"�6&   $��Race:��68   $��10,0,0,0q�6H   	� 5,      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $	��Elf��6�   $ p1Race��6   6`   �� $ p1Race�#	 [    dev.Race
   Elf# Z $ PropertyChanged=�6  	� 5-      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $	��Orc��6�   $ p1Race��6   6`   �� $ p1Race�#	 [  
   Orc# Z $ PropertyChanged=�6  	� 5.      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $��Human��6�   $ p1Race��6   6`   �� $ p1Race�#	 [     Human# Z $ PropertyChanged=�6  5/      �� 50      $��1��6   $ Vertical=�6)   $��10,0,0,0q�6@   .+�51      �� $��20(�6   $
��Bold"�6'   $��	Player 2:��69   $��10,0,0,5q�6M   �� 52      $��20(�6   $
��Bold"�6'   $��Name:��69   $��10,0,0,0q�6I   �� 53      $��10,0,0,0q�6   $	��150��6D   $
��Left=�6P   ��6,   �� *p2Name+6P   �� 54      $��20(�6   $
��Bold"�6'   $��Race:��69   $��10,0,0,0q�6I   	� 55      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $	��Elf��6�   $ p2Race��6   6`   �� $ p2Race�#	 [  # Z $ PropertyChanged=�6  	� 56      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $	��Orc��6�   $ p2Race��6   6`   �� $ p2Race�#	 [  # Z $ PropertyChanged=�6  	� 57      $��10,0,0,0q�6   $��20(�60   $��Center=�6>   $��Human��6�   $ p2Race��6   6`   �� $ p2Race�#	 [  # Z $ PropertyChanged=�6  58      59      � 5:   
   $��3��6    5;      �� 5<      $
��345* �6#   �� 5=      $
��448* �6#   .+�5?      �� $��50(�6   
�������$��Center=�66   $��Center=�6Q   $
��Play��6�   ��6n   �� *Play+6�   �� 5@      $��50(�6   
�������$��Center=�66   $��Center=�6Q   $��	Load game��6�   $��1��6�   $��73��6�   $	��269��6�   ��6n   �� *Load+6�   5A      5C      5D      