   M S B A M L   `   `   `  ����  SUR_CSTG3    -SUR_CSTG.Views.AreaViews.DeleteAreaWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Usuwanie rejonu��5   	    � WindowStartupLocation$ CenterScreen=�6!   $	��300��5   	   $	��350��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��5��6!   $(��"Na pewno chcesz usunąć ten Rejon��65   $
��Bold"�6]   $��14(�6o   $��Center=�6}   $��Center=�6�   �� 5   
   $��1��6   $��0��6!   $��Nazwa: ��5      $��Right=�6#   $��14(�6?   5      �� 5   
   $��1��6   $��1��6!   $��14(�61   $
��Left=�5   �   ��6   ��  �� Path$ AreaToDelete.Name� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� Mode$ TwoWay=�5      �� 5   
   $��2��6   $��5��6!   �� 5   
   $��3��6   $��0��6!   $��Opis: ��5      $��Right=�6"   $��14(�6>   5       �� 5!   
   $��3��6   $��1��6!   $��14(�61   $
��Left=�5"   �   ��6   �� $ AreaToDelete.Description�$ PropertyChanged=� . $ TwoWay=�5#      �� 5$   
   $��4��6   $��5��6!   �� 5%   
   $��5��6   $��5��6"   .+�5&      �  5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      .+�5.      �� $��Usuń��6   $��1��6(   $��14(�68   ��6F   �� $ DeleteCommand��� 5/      $��Anuluj��6   $��14(�6*   $��3��68   ��6H   �� $ CloseCommand�50      51      52      53      