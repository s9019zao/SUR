   M S B A M L   `   `   `  ����  SUR_CSTG4    .SUR_CSTG.Views.BreakdownViews.AddBreakdownView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
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
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      �� 5      �� 5      $
��0.5* �6   �� 5      �� 5       �� 5!      $
��0.5* �6   .+�5#   
   �� $��0��6   $��7��6!   $��20(�65   �� 5$   
   $��1��6   $��1��6!   $��Imię: ��5%   
   $��Right=�6   $��14(�64   �� 5&   
   $��2��6   $��7��6!   $��20(�65   �� 5'   
   $��1��6   $��2��6   $��14(�6/    �� 
IsReadOnly . ��5(      ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� Mode$ TwoWay=�.��6y   5)      �� 5*   
   $��4��6   $��7��6!   $��20(�65   �� 5+   
   $��1��6   $��4��6!   $��
Nazwisko: ��5,   
   $��Right=�6   $��14(�68   �� 5-   
   $��1��6   $��5��6   $��14(�6/    . ��5.      �� $ Surname�$ PropertyChanged=� . $ TwoWay=�.��6|   5/      �� 50   
   $��2��6   $��7��6!   $��14(�65   �� 51   
   $��3��6   $��1��6!   $��Rejon: ��52   
   $��Right=�6   $��14(�65   �� 53   
   $��3��6   $��2��6    $��3��60   $��14(�6D    �� DisplayMemberPath$
 Name��55      $��0,5,0,23q�56   >   $��2��6P   ��54      �� $ AllAreas�$ PropertyChanged=� . $ TwoWay=� �� SelectedItem 56      �� $ SelectedArea�57      �� 58   
   $��4��6   $��7��6!   $��20(�65   �� 59   
   $��5��6   $��1��6!   $��Urządzenie: ��5:   
   $��Right=�6   $��14(�6:   �� 5;   
   $��5��6   $��2��6    $��3��60   $��14(�6D   $
 Name��5=      ��5<      �� $ DevicesArea�$ PropertyChanged=� . $ TwoWay=� 5>      �� $ SelectedDevice�5?      �� 5@   
   $��6��6   $��7��6!   $��20(�65   �� 5A   
   $��7��6   $��1��6!   $��Rodzaj: ��5B   
   $��Right=�6   $��14(�66   �� 5C   
   $��7��6   $��2��6    $��3��60   $��14(�6D   ��5D      �� $ TypeBreakdown�$ PropertyChanged=� . $ TwoWay=� 5E      �� $ SelectedBreakedownType�5F      �� 5G   
   $��9��6   $��4��6!   $��	Godzina: ��5H   
   $��Right=�6   $��14(�67   �� 5I   
   $��8��6   $��7��6!   $��20(�65   �� 5J   
   $��9��6   $��1��6!   $��Data: ��5K      $��Right=�6"   $��14(�6>   5L      �� 5M   
   $��9��6   $��2��6   $��14(�6/   .��6=   ��5N      �� 5O      $ RequestDate�6   	 �� StringFormat$	 
dd.MM.yyyy��6-   $ PropertyChanged=�6G   
 �� ValidatesOnDataErrors
 . 6m   .��5P      5Q      �� 5R   
   $��9��6   $��5��6   $��14(�6/   .��6=   ��5S      �� 5T      $ RequestDate�6   $	 HH:mm��6-   $ PropertyChanged=�6B   
 . 6h   .��5U      5V      �� 5W   
   $��10��6   $��7��6"   $��20(�66   �� 5X   
   $��11��6   $��1��6"   $��Opis: ��5Y      $��Right=�6"   $��14(�6>   5Z      �� 5[   
   $��11��6   $��2��6    $��4��60   $��14(�6D    . .��6d   5\      �� 5]   
   $��12��6   $��7��6"   $��20(�66   �� 5^   
   $��Dodaj��6   $��13��6!   $��2��6/   $��14(�6?   ��6M   �� $ AddBreakdownCommand��� 5_   
   $��Anuluj��6   $��13��6"   $��5��60   $��14(�6A   ��6O   �� $ CloseCommand��� 5`   
   $��14��6   $��7��6"   $��20(�66   5e      5f      