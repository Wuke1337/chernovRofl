   M S B A M L   `   `   `  ����F  BchernovRofl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:chernovRofl.PageschernovRofl.Pages  5          chernovRofl.Pages.PDFPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:chernovRofl.Pages     5        N� Title$  PDFPage��5	      .��5      � $	��850��6    � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ OtchetDG��5      $��Stretch=�6%      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Табельный номер��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *ServID+  5      $. (Фамилия, имя, отчество��6%    6E   �� *FIO+  5      $1 +Среднедневная зарплата��6%    6E   �� *Salary+  5      $2 ,Количество дней болезни��6%    6F   �� *
DaysIllnes+  5      $! Процент оплаты��6%    6=   �� *	ProcPay+  5      $ 
Сумма��6%    64   �� *Sum+ �� StringFormat$ F2��5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��1��6.   $��60��6;   .+�5      �� -   5        
 ��Name$
 	OtchetBtn��5      $&�� Создать отчёт в PDF��6(   $��5q�6F   $��30��6Q   $	��150��6]   6i   �� 5      -   5        $
 NazadBtn��5      $��
Назад��6'   $��5q�67   $��30��6B   $	��150��6N   6Z   5      5      5      