   M S B A M L   `   `   `  ����C  ?SUR_CSTG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SUR_CSTG.Views.PartViewsSUR_CSTG.Views.PartViews  5      '    !SUR_CSTG.Views.PartViews.PartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8views&clr-namespace:SUR_CSTG.Views.PartViews     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��0.05* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��0.05* �6   �� 5      $	��300 �6    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��1��6   $��5��6!   $ ��SUR_CSTG Obsługa części��65   $
��Bold"�6T   $��Center=�6f   $��20(�6�   $��Center=�6�   �� 5   
   $��2��6   $��5��6!   $�� ��65   $
��Bold"�6=   $��Center=�6O   $��20(�6l   $��Center=�6z   +   %SUR_CSTG.Views.PartViews.PartListView  5   
   $��5��6   $��3��6*   $��Center=�6i   $��Center=�6�    � DataContext 6:   ��  �� Path$ PartListViewModel�6�   �� 5   
   $��3��6   $��3��6"   $��Center=�62   .+�5      �  5      �� 5      $
��Auto �6'   �� 5       $��10 �6'   �� 5!      $
��Auto �6'   �� 5"      $��10 �6'   �� 5#      $
��Auto �6(   .+�5&      �� $��0��6   $��Części Elektryczne��6)   $��14(�6F   ��5'      �� $ ShowElectricalPartCommand�6N   �� 5(      $��2��6   $��Części Mechaniczne��6)   $��14(�6F   ��5)      �� $ ShowMechanicalPartCommand�6N   �� 5*      $��4��6   $��Części Automatyczne��6)   $��14(�6G   ��5+      �� $  ShowAutomaticalPartCommand�6O   5,      5-      �� 5.   
   $��5��6   $��1��6"   .+�5/      �   50      �� 51      $��10 �6$   �� 52      $
��Auto �6$   �� 53      $��10 �6$   �� 54      $
��Auto �6$   �� 55      $��10 �6$   �� 56      $
��Auto �6$   �� 57      $��10 �6$   �� 58      $
��Auto �6$   �� 59      $��10 �6$   .+�5;      �� $��Dodaj��6   $��1��6)   $��14(�66   ��5<      �� $ OpenAddPartCommand�5=      �� 5>      $��Edytuj��6   $��3��6*   $��14(�67   ��5?      �� $ OpenEditPartCommand�5@      �� 5A      $��Usuń��6   $��5��6(   $��14(�65   ��5B      �� $ OpenDeletePartCommand�5C      �� 5D      $!��Zmień ilość na magazynie��6   $��7��6<   $��14(�6I   ��5E      �� $! OpenEditQuantityPartCommand�5F      5G      5H      5I      5J      