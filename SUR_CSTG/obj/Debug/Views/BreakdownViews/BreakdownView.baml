   M S B A M L   `   `   `  ����C  ?SUR_CSTG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SUR_CSTG.Views.BreakdownViewsSUR_CSTG.Views.BreakdownViews  5      1    +SUR_CSTG.Views.BreakdownViews.BreakdownView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =views+clr-namespace:SUR_CSTG.Views.BreakdownViews     5      .��5	      �   � RowDefinitions  5
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
��Bold"�6=   $��Center=�6O   $��20(�6l   $��Center=�6z   5   /SUR_CSTG.Views.BreakdownViews.BreakdownListView  5   
   $��5��6"   $��3��6/   $	��Top=�6s   $��Center=�6�    � DataContext 6?   ��  �� Path$ BreakdownListViewModel�6�   �� 5   
   $��3��6   $��3��6"   $��Center=�62   .+�5      �  5      �� 5      $
��Auto �6'   �� 5       $��10 �6'   �� 5!      $
��Auto �6'   �� 5"      $��10 �6'   �� 5#      $
��Auto �6(   .+�5&      �� $��0��6   $��Awarie Elektryczne��6)   $��14(�6F   ��5'      �� $$ ShowElectricalBreakdownCommand�6S   �� 5(      $��2��6   $��Awarie Mechaniczne��6)   $��14(�6F   ��5)      �� $$ ShowMechanicalBreakdownCommand�6S   �� 5*      $��4��6   $��Awarie Automatyczne��6)   $��14(�6G   ��5+      �� $% ShowAutomaticalBreakdownCommand�6T   5,      5-      �� 5.   
   $��5��6   $��1��6"   .+�5/      �   50      �� 51      $��10 �6$   �� 52      $
��Auto �6$   �� 53      $��10 �6$   �� 54      $
��Auto �6$   �� 55      $��10 �6$   �� 56      $
��Auto �6$   �� 57      $��10 �6$   �� 58      $
��Auto �6$   �� 59      $��10 �6$   �� 5:      $
��Auto �6$   .+�5<      �� $��Dodaj��6   $��1��6)   $��14(�66   ��5=      �� $ OpenAddBreakdownCommand�5>      �� 5?      $��Edytuj��6   $��3��6*   $��14(�67   ��5@      �� $ OpenEditBreakdownCommand�5A      �� 5B      $��Coś na pewno 1��6   $��5��62   $��14(�6?   ��5C      �� $ OpenDeletePartCommand�5D      �� 5E      $��Zmień Status��6   $��7��60   $��14(�6=   ��5F      �� $* $OpenChangeStatusBreakdownViewCommand�5G      �� 5H      $��9��6!   ��6.   �� *SelectedViewChangeStatus+5I      5J      5K      5L      