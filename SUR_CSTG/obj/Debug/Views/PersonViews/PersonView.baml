   M S B A M L   `   `   `  ����C  ?SUR_CSTG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SUR_CSTG.Views.PersonViewsSUR_CSTG.Views.PersonViews  5      +    %SUR_CSTG.Views.PersonViews.PersonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :views(clr-namespace:SUR_CSTG.Views.PersonViews     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��0.05* �6   �� 5      $
��Auto �6   �� 5      $��0.05* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��1��6   $��5��6!   $$��SUR_CSTG Obsługa pracowników��65   $
��Bold"�6Y   $��Center=�6k   $��20(�6�   $��Center=�6�   /   )SUR_CSTG.Views.PersonViews.PersonListView  5   
   $��3��6   $��3��6,   $��Center=�6m   $��Center=�6�    � DataContext 6<   ��  �� Path$ PersonListViewModel�6�   �� 5   
   $��3��6   $��1��6"   .+�5      �   5      �� 5      $��10 �6$   �� 5      $
��Auto �6$   �� 5      $��10 �6$   �� 5      $
��Auto �6$   �� 5       $��10 �6$   �� 5!      $
��Auto �6$   �� 5"      $��10 �6$   �� 5#      $
��Auto �6$   .+�5&      �� $��Dodaj��6   $��1��6)   $��14(�66   ��5'      �� $ OpenAddPersonCommand�5(      �� 5)      $��Edytuj��6   $��3��6*   $��14(�67   ��5*      �� $ OpenEditPersonCommand�5+      �� 5,      $��Usuń��6   $��5��6(   $��14(�65   ��5-      �� $ OpenDeletePersonCommand�5.      �� 50      $��Zmień swoje hasło��6   $��7��65   $��14(�6B   ��51      �� $) #OpenChangePasswordWindowViewCommand�52      54      55      56      57      