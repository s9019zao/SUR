   M S B A M L   `   `   `  ����  SUR_CSTG7    1SUR_CSTG.Views.PersonViews.DeletePersonWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Usuwanie danych pracownika��5   	    � WindowStartupLocation$ CenterScreen=�6,   $	��350��5   	   $	��500��6   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��5��6!   $0��*Na pewno chcesz usunąć dane pracownika ?��65   $
��Bold"�6e   $��14(�6w   $��Center=�6�   $��Center=�6�   �� 5    
   $��1��6   $��0��6!   $��Imię: ��5!      $��Right=�6"   $��14(�6>   5"      �� 5#   
   $��1��6   $��1��6!   $��14(�61   $
��Left=�5$   �   ��6   ��  �� Path$ PersonToDelete.Name� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� Mode$ TwoWay=�5%      �� 5&   
   $��2��6   $��5��6!   �� 5'   
   $��3��6   $��0��6!   $��
Nazwisko: ��5(      $��Right=�6&   $��14(�6B   5)      �� 5*   
   $��3��6   $��1��6!   $��14(�61   $
��Left=�5+   �   ��6   �� $ PersonToDelete.Surname�$ PropertyChanged=� . $ TwoWay=�5,      �� 5-   
   $��4��6   $��5��6!   �� 5.   
   $��5��6   $��0��6!   $��Login: ��5/      $��Right=�6#   $��14(�6?   50      �� 51   
   $��5��6   $��1��6!   $��14(�61   $
��Left=�52   �   ��6   �� $ PersonToDelete.Login�$ PropertyChanged=� . $ TwoWay=�53      �� 54   
   $��6��6   $��5��6!   �� 55   
   $��7��6   $��0��6!   $��Stanowisko: ��56      $��Right=�6(   $��14(�6D   57      �� 58   
   $��7��6   $��1��6!   $��14(�61   $
��Left=�59   �   ��6   �� $ PersonToDelete.Position�$ PropertyChanged=� . $ TwoWay=�5:      �� 5;   
   $��8��6   $��5��6!   �� 5<   
   $��9��6   $��0��6!   $��Nr telefonu: ��5=      $��Right=�6)   $��14(�6E   5>      �� 5?   
   $��9��6   $��1��6!   $��14(�61   $
��Left=�5@   �   ��6   �� $  PersonToDelete.PhoneNumber�$ PropertyChanged=� . $ TwoWay=�5A      �� 5B   
   $��10��6   $��5��6"   �� 5D   
   $��11��6   $��5��6#   .+�5F      �  5G      �� 5H      �� 5I      �� 5J      �� 5K      �� 5L      .+�5N      �� $��Usuń��6   $��1��6(   $��14(�68   ��6F   �� $ DeleteCommand��� 5O      $��Anuluj��6   $��14(�6*   $��3��68   ��6H   �� $ CloseCommand�5P      5Q      5R      5T      