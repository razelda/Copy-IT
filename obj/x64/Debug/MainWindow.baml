   M S B A M L   `   `   `  ����B  >Copy IT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Copy_ITCopy_IT  5           Copy_IT.MainWindow   5   	   =dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'localclr-namespace:Copy_IT     5       -   5          �Name$  Window��5   F    � Title$ Copy IT��5   	   ���	#ffe6e6e6$	��400��5   V   $	��750��6c    � 	Resources 5         Copy_IT.ExpandedConverter   ExspandedConerter  DataTemplate1$   Copy_IT.ExpandedMultiConverter  Key 9� 
IsExpanded  ExpandedMultiConverter `� 	Converter �� Path �� Mode �� ElementName��%�  &	        &	      7    5   
   6"   �� 5
   
   .R�5      9� ��6   �� *Header+��61   �� *	Content+ 5      ��  5      ExpandedMultiConverter 63   5       5      `� 5      8   .1�5      �� $ CurrentExpanded1�6"   $ TwoWay=�6:   $ Window��6H   �� 5      $ ItemId�6"   $ OneWay=�60   5      5      5      5      .��5      � .+�5   
   �� $
��Left=�6   $	��195��60   $��Center=�6<   .+�5      9�   ExpanderStyle1#��[ 6   $��Folder Locations��6?    6Z   �� *CurrentExpanded2+ �� 	Converter# [  	 �� ConverterParameter$	 1��.��5       � ���	#FFE5E5E5$	��209��6.   .+�5!      �� $
��Left=�6    $��
15,0,0,190q�6;   $
��Wrap=�6O   $��Source Directory: ��6c   $	��137��6}   �� 5"      -   5        
 ��Name$
 TB_SorceDir��5"      $��22��64   $��15,19,41,168q�6@   �� 5#      -   5         ��Name$ BT_Sorce��5#      $	��...��6/   $
��Left=�6=   $��
157,19,0,0q�6X   $	��Top=�6l   $��26��6�   �� 5$      $
��Left=�6    $��15,44,0,146q�6;   $
��Wrap=�6P   $��Destanation Directory: ��6d   $	��137��6�   �� 5%      -   5        $
 
TB_DestDir��5%      $
��Left=�62   $��22��6M   $��	15,63,0,0q�6Y    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��137��6�   �� 5&      -   5        $ BT_Dest��5&      $	��...��6.   $
��Left=�6<   $��
157,63,0,0q�6W   $	��Top=�6k   $��26��6�   5'      5(      9� 5)      #��[ 6   $��Copy Options��6?    6V   �� *CurrentExpanded2+# [  $	 2��.��5*      � ���	#FFE5E5E5$	��209��6.   .+�5+      �� $��	Recursive��6   $
��Left=�63   $	��Top=�6N   $��	10,10,0,0q�6f   �� 5,      $��Hidden Files��6   $
��Left=�66   $��	10,30,0,0q�6Q   $	��Top=�6d   �� 5-      $ ��Retry 10 times (defult: 5)��6   $
��Left=�6D   $��	10,50,0,0q�6_   $	��Top=�6r   51      52      9� 53      #��[ 6   $��Ownership Options��6?    6[   �� *CurrentExpanded2+# [  $	 3��.��54      � ���	#FFE5E5E5$	��209��6.   55      9� 56      #��[ 6   $��
Permisions��6?    6T   �� *CurrentExpanded2+# [  $	 4��.��57      � ���	#FFE5E5E5$	��209��6.   58      59      �� 5=   
   -   5        $��Big Red Button��5=      $
��Left=�6*   $��360,309,0,0q�6E   $	��Top=�6Z   $	��110��6r   ���	#FFFB0000$��34��6�   6�   5?      5@      