   M S B A M L   `   `   `  ����C  ?SUR_CSTG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SUR_CSTG.AssistantSUR_CSTG.Assistant  5      3    -SUR_CSTG.Views.PersonViews.ChangePasswordView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1pass clr-namespace:SUR_CSTG.Assistant     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      �� 5      �� 5      $
��0.3* �6    .+�5   
   �� $��0��6   $��5��6!   �� 5   
   $��1��6   $��1��6!   $��Stare hasło: ��5   
   $��Right=�6   $��14(�6;   G� 5   
   $��1��6   $��2��6#   $��2��63   $��14(�6G   -   'SUR_CSTG.Assistant.PasswordBoxAssistant   BindPassword .    BoundPassword 5!      ��  �� Path$ Password� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5"   
   $��2��6   $��5��6!   �� 5#   
   $��3��6   $��1��6!   $��Nowe hasło: ��5$      $��Right=�6(   $��14(�6D   5%      G� 5&   
   $��3��6   $��2��6#   $��2��63   $��14(�6G    .  5(      �� $ NewPassword�$ TwoWay=�$ PropertyChanged=��� 5)   
   $��4��6   $��5��6!   �� 5*   
   $��5��6   $��1��6!   $��Powtórz nowe hasło: ��5+      $��Right=�60   $��14(�6L   G� 5,   
   $��5��6   $��2��6#   $��2��63   $��14(�6G    .  5.      �� $ ConfirmPassword�$ TwoWay=�$ PropertyChanged=��� 5/   
   $��6��6   $��5��6!   �� 50   
   $��7��6   $��1��6"   $��3��62   .+�51      �  52      �� 53      �� 54      �� 55      �� 56      �� 57      .+�59      �� $��Zmień��6   $��14(�6)   $��1��67   ��6G   �� $ ChangePasswordCommand��� 5:      $��Anuluj��6   $��14(�6*   $��3��68   ��6H   �� $ CloseCommand�5;      5<      5=      5>      