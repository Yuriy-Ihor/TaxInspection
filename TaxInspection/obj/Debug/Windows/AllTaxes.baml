   M S B A M L   `   `   `  ����  TaxInspection$    TaxInspection.Windows.AllTaxes   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Податки��5   	   $	��420��6   $	��600��6&   .��5      � ��5	   
   �� 5
       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ White��6    � Offset$ 0Q�6-   � 5      $ 	#FFB4B4B4��6   $ 1Q�61   5      .+�5   
   �� -   5         ��Name$ ListOfTaxes��5      $
��Left=�6(    �� SelectionMode$ Single=�6C   $	��270��6Z   $��	47,42,0,0q�6g   $	��Top=�6z   $	��507��6�   
���   ����	#FFE0E0E0
������� � Cursor$  ��6�    �� View 5      �� 5      .P�5      �� $��Назва податку��6%   	 �� Width$		 200��6<   
 �� DisplayMemberBinding
 6H   �� *	TaxName+�� 5      $��Дійсний��6%   $	 80��66    �� CellTemplate 5      �� 5      .R�5   "   ��  d� 	IsChecked 6+   ��  �� Path$ IsValid� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      5      �� 5      $��Документ��6%   $		 222��67   
 6C   �� *DocumentName+5      5      �� 5   
   -   5         ��Name$ CreateNewTaxButton��5      $,��&Додати новий податок��6-   $
��Left=�6L   $��44��6g   $��108,329,0,0q�6s   $	��Top=�6�   $	��150��6�   ���	#FF6D9E56���	#FF838D45
�������$��Verdana)�6   �� 5   
   -   5        $ RemoveSelectedTaxButton��5      $8��2Видалити вибраний 
податок��62   $
��Left=�6`   $��44��6{   $��327,329,0,0q�6�   $	��Top=�6�   $	��150��6�   ���	#FFC74343���	#FFB9B9B9$��Verdana)�6	  
�������6  5       5!      