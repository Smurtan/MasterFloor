   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	   *    $WpfApp1.Windows.HistoryProductsSales   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$R  LМастер пол - история реализации продукции��5   	   $	��400��5	   	   $	��600��6   $	��450��5
   	   $	��800��6   $��Segoe UI)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��5* �6   �� 5      $��* �6   $��40��6'   .+�5   
   ]� $��0��6      AccentColor#���   5      .+�5      �� $*��$../Resources/Мастер пол.png��6   $
��Left=�5      $��10q�5      �� 5      $��28(�6   $
��Bold"�5      $
��Left=�5      $��Center=�5      86История реализации продукции6I   5      �� 5!   
   -   5         ��Name$ ListHistoryProductsSales��5!      $��1��5"      $��Disabled=�5#      ��5$      �� 5%       �� 
TargetType" ��6   .�5&      ��  �� Property � �� �� Value$ Stretch=�6C   �� 5'       � ��$
 10 5q�6/   5(      ��5*      �� 5+      .R�5,      �� $��1q�6   #���   5-        PrimaryBgColor#���  5.      ._�5/      � $��10q�6   $��Stretch=�50       � ColumnDefinitions 51      �� 52   "   $��2* �63   �� 53   "   $��* �63   �� 54   "   $��* �63   .+�57      �� $��0��6(   $��18(�58   (   $
��Wrap=�5:   (   ��59   (   �� *TitleProduct+5:   (   �� 5;      $��1��6(   $��Center=�5<   (   $
��Wrap=�5>   (   ��5=   (   �� *CountProduct+ �� StringFormat$ 	{0} шт.��5>   (   �� 5?      $��2��6(   $��Center=�5@   (   ��5A   (   �� *
DateString+5B      5C      5D      5F      �� 5H   
   -   5         ��Name$ BackBtn��5H      $��3��5I      $��Right=�5J      $��80��5K      $
��10 0q�5L        SecondaryBgColor#���  5N      .��6A   
Назад6H   5O      5P      