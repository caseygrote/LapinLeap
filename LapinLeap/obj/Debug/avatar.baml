   M S B A M L   `   `   `  ����  	LapinLeap    LapinLeap.avatar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      I EWpfAnimatedGif, Version=1.4.4.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      .��5	      � .+�5
   
   �� -   5          ��Name$  standing��5
      $��Resources/stand.png��6"   $	��190��6?   $��
21,296,0,0q�6L   $	��Top=�6`   $
��Left=�6x   $��82��6�    J� OpacityMask 5      �� 5       �� ImageSource$ Resources/stand.png��6   5      �� 5   
   -   5        $  leftfwdanim��5      $	��193��6&   $��
10,293,0,0q�63   $	��Top=�6G   $
��Left=�6_   $	��138��6z   $y�Hidden=�5      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Resources/left.gif��5         RepeatBehavior$ 1x��5         	AutoStart .   5      �� 5      $ Resources/left.gif��6    j� Stretch$ Uniform=�6>   5      �� 5   
   -   5        $  leftbwdanim��5      $	��193��6&   $��291,293,0,0q�63   $	��Top=�6H   $
��Left=�6`   $	��114��6{   $y�Hidden=�5       J� RenderTransformOrigin$ 0.5,0.5&�6$   $ Resources/left.gif��5      $ 1x��5       .  z�5      V� 5       .~�5!      ��  �� ScaleX$ -1Q�6%   �� 5"      �� 5#      T� 5$      5%       5(      �� 5)      $ Resources/left.gif��6   $ Uniform=�6>   5+      �� 5,   
   -   5        $  rightfwdanim��5,      $	��193��6&   $��153,296,0,0q�63   $	��Top=�6H   $
��Left=�6`   $	��138��6{   $y�Hidden=�5-      $ Resources/right.gif��6$   $ 1x��5.       .  53      �� 54   
   -   5        $  rightbwdanim��54      $	��193��6&   $��153,296,0,0q�63   $	��Top=�6H   $
��Left=�6`   $	��138��6{   $y�Hidden=�55      $ Resources/right.gif��56      $ 1x��57       .  5<      5>      5?      