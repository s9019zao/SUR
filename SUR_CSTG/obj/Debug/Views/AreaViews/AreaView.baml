   M S B A M L   `   `   `  ����C  ?SUR_CSTG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SUR_CSTG.Views.AreaViewsSUR_CSTG.Views.AreaViews  5      '    !SUR_CSTG.Views.AreaViews.AreaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8views&clr-namespace:SUR_CSTG.Views.AreaViews     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��300 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��300 �6    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��0��6   $��5��6!   �� 5   
   $��1��6   $��5��6!   $ ��SUR_CSTG Obsługa rejonów��65   $
��Bold"�6U   $��Center=�6g   $��20(�6�   $��Center=�6�   �� 5   
   $��2��6   $��5��6!   �� 5    
   $��3��6   $��1��6"   .+�5!      �   5"      �� 5#      $��10 �6$   �� 5$      $
��Auto �6$   �� 5%      $��10 �6$   �� 5&      $
��Auto �6$   �� 5'      $��10 �6$   �� 5(      $
��Auto �6$   �� 5)      $��10 �6$   .+�5+      �� $��Dodaj��6   $��1��6)   $��14(�66   ��5,      ��  �� Path$ OpenAddAreaCommand�5-      �� 5.      $��Edytuj��6   $��3��6*   $��14(�67   ��5/      �� $ OpenEditAreaCommand�50      �� 51      $��Usuń��6   $��5��6(   $��14(�65   ��52      �� $ OpenDeleteAreaCommand�53      54      55      +   %SUR_CSTG.Views.AreaViews.AreaListView  56   
   $��3��6   $��3��6*   $	��Top=�6i   $��Center=�6�    � DataContext 6:   �� $ AreaListViewModel�6�   �� 57   
   $��4��6   $��5��6!   �� 58   
   $��5��6   $��5��6!   $��Wyszukiwarka rejonów��65   $��Center=�6Q   $��Center=�6n   $��18(�6�   $
��Bold"�6�   �� 59   
   $��6��6   $��5��6!   �� 5:   
   $��7��6   $��3��6"   .+�5;      �  5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A      .+�5C      �� $��0��6   $��2��6-    �� Orientation$ 
Horizontal=�6A   .+�5D      �� $��Nazwa rejonu :��6    $��Right=�66   $��Center=�6R   $��10,15q�6m   �� 5E      $��
0,15,10,15q�6   $	��100��62   ��5F      �� $ NameToSerch� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� Mode$ TwoWay=�5G      �� 5H      $��2��6   $��2��6-   $ 
Horizontal=�6A   .+�5I      �� $��Opis rejonu :��6    $��Right=�65   $��10,15q�6Q   �� 5J      $��
0,15,10,15q�6   $	��100��62   ��5K      �� $ DescriptionToSerch�$ PropertyChanged=� . $ TwoWay=�5L      �� 5M      $��4��6   $��Wyszukaj��6)   $��10,15q�6<   $��66��6K   ��5N      �� $ SerchAreaCommand�5O      5P      �� 5Q   
   $��8��6   $��5��6!   0   *SUR_CSTG.Views.AreaViews.AreaSerchListView  5R   
   $��9��6"   $��3��6/   $	��Top=�6s   $��Center=�6�    6?   �� $ AreaSerchListViewModel�6�   5S      5T      