   M S B A M L   `   `   `  ����  SUR_CSTG&     SUR_CSTG.Views.GeneralWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  GeneralWindowView��5   	    � WindowState$ 	Maximized=�5   	   $	��300��5   	   $	��300��6   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��3��6!   $��Jesteś zalogowany jako: ��61   $��Right=�6Q   �� 5   
   $��0��6   $��4��6!   $
��Bold"�61   $
��Left=�5   �   ��6   ��  �� Path$ NameSurname� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� Mode$ TwoWay=�6�   �� 5   
   $��0��6   $��5��6!   $��Stanowisko: ��61   $��Right=�6E   �� 5   
   $��0��6   $��6��6!   $
��Bold"�61   $
��Left=�5   �   ��6   �� $ Position�$ PropertyChanged=� . $ TwoWay=�6�   �� 5   
   $��0��6   $��7��6   $��Wyloguj��6.   ��6@   �� $ LogoutCommand�6i   �� 5   
   $��1��6   $��8��6!   $��SUR_CSTG��65   $��35(�6E   $
��Bold"�6S   $��Center=�6e   $��Center=�6�   �� 5    
   $��2��6   $��0��6   $��
Pracownicy��6.   ��6C   �� $ OpenPersonViewCommand��� 5!   
   $��2��6   $��1��6   $��Awarie��6.   ��6?   �� $ OpenBreakdownViewCommand��� 5"   
   $��2��6   $��2��6   $��Przeeglądy��6.   6E   �� 5#   
   $��2��6   $��3��6   $��Urządzenia��6.   ��6C   �� $ OpenDeviceViewCommand��� 5$   
   $��2��6   $��4��6   $��Rejony��6.   ��6?   �� $ OpenAreaViewCommand��� 5%   
   $��2��6   $��5��6   $��yyyyyy��6.   6A   �� 5&   
   $��2��6   $��6��6   $��yyyyyy��6.   6A   �� 5'   
   $��2��6   $��7��6   $��Części��6.   ��6?   �� $ OpenPartViewCommand��� 5(   
   $��3��6   $��8��6   ._�5)      �� ��6   �� *SelectedView+5*      5+      5,      