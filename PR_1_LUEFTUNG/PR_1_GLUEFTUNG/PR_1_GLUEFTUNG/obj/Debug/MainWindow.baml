   M S B A M L   `   `   `  ����I  EPR_1_GLUEFTUNG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PR_1_GLUEFTUNGPR_1_GLUEFTUNG  5   	   ?$clr-namespace:PR_1_GLUEFTUNG.ControlPR_1_GLUEFTUNG.Control  5   	   C&clr-namespace:PR_1_GLUEFTUNG.ViewModelPR_1_GLUEFTUNG.ViewModel  5   	       PR_1_GLUEFTUNG.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PR_1_GLUEFTUNG     5   	   2l$clr-namespace:PR_1_GLUEFTUNG.Control     5   	   4h&clr-namespace:PR_1_GLUEFTUNG.ViewModel     5   	     � Title$  
MainWindow��5
   	   $��396.192��6   $��445.031��6-    � 	Resources 5      (   "PR_1_GLUEFTUNG.SpecStringConverter   strconverter��%   &	          5   
   6$   5       � DataContext 5      ,   &PR_1_GLUEFTUNG.ViewModel.VentViewModel  5   
   .��5      � .+�5   
   �� -   5        $��lbl_EngStatus��5      $��Zustand Lüftung��6%   $
��Left=�6?   $��
12,154,0,0q�6Z   $	��Top=�6n   $	��109��6�   $��Right=�6�   �� 5   
   -   5        $��lbl_EngVoltage��5      $��Spannung [V]��6&   $
��Left=�6=   $��
12,184,0,0q�6X   $	��Top=�6l   $	��109��6�   $��Right=�6�   �� 5   
   -   5        $��lbl_EngCurrent��5      $��
Strom [mA]��6&   $
��Left=�6;   $��
12,214,0,0q�6V   $	��Top=�6j   $	��109��6�   $��Right=�6�   �� 5   
   -   5        $��lbl_EngSpeed��5      $��Drehzahl [U/min]��6$   $
��Left=�6?   $��
12,244,0,0q�6Z   $	��Top=�6n   $	��109��6�   $��Right=�6�   �� 5   
   -   5        $��lbl_EngPower��5      $��Leistung [W]��6$   $
��Left=�6;   $��
12,274,0,0q�6V   $	��Top=�6j   $	��109��6�   $��Right=�6�   �� 5   
   -   5        $��lbl_Val_EngStatus��5      $
��Left=�6O   $��137,154,0,0q�6j   $	��Top=�6   $��74��6�   $
��Bold"�6�   $��26��6�   ���	#FFE4E4E4��6)   �� *Fan_1.Eng_IsOnOff+6�   �� 5   
   -   5        $��lbl_Val_EngVoltage��5      $
��Left=�6y   $��137,184,0,0q�6�   $	��Top=�6�   $��74��6�   $
��Bold"�6�   $��26��6�   ���	#FFE4E4E4��6*   �� *Fan_1.Eng_Voltage+ �� 	Converter# [  6�   �� 5   
   -   5        $��lbl_Val_EngCurrent��5      $
��Left=�6z   $��137,214,0,0q�6�   $	��Top=�6�   $��74��6�   $
��Bold"�6�   $��26��6�   ���	#FFE4E4E4��6*   �� *Fan_1.Eng_Current+# [  6�   �� 5   
   -	   5        $��lbl_Val_EngSpeed��5      $
��Left=�6u   $��137,244,0,0q�6�   $	��Top=�6�   $��74��6�   $
��Bold"�6�   $��26��6�   ���	#FFE4E4E4��6(   �� *Fan_1.Eng_Speed+# [  6�   �� 5   
   -
   5        $��lbl_Val_EngPower��5      $
��Left=�6u   $��137,274,0,0q�6�   $	��Top=�6�   $��74��6�   $
��Bold"�6�   $��26��6�    J� SnapsToDevicePixels . ���	#FFE4E4E4��6(   �� *Fan_1.Eng_Power+# [  6  �� 5   
   -   5        $��lbl_ActLevel��5      $��Aktive Stufe��6$   $
��Left=�6;   $��
12,305,0,0q�6V   $	��Top=�6j   $	��109��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ lbl_Val_ActLevel��5      $
��Left=�6Q   $��137,305,0,0q�6l   $	��Top=�6�   $��74��6�   $
��Bold"�6�   $��26��6�    . ���	#FFE4E4E4��6*   �� *Ctrl_1.ActiveLevel+6�   � 5   
   -   5        $��btn_area��5      $
��Left=�6   $	��128��6:   $��
320,26,0,0q�6G   $	��Top=�6[   $	��100��6s   .+�5       �� 
���   �$��2q�6)   �� 5!      -   5        $��
btn_ReqOff��5!      $	��AUS��6'   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   $��80��6{   ��6�   �� *Ctrl_1.RequestLevelOff+�� 5"      -   5        $��btn_ReqLvl_1��5"      $��Stufe 1��6)   $
��Left=�6;   $��	10,37,0,0q�6V   $	��Top=�6i   $��80��6�   ��6�   �� *Ctrl_1.RequestLevel1+�� 5#      -   5        $��btn_ReqLvl_2��5#      $��Stufe 2��6)   $
��Left=�6;   $��	10,64,0,0q�6V   $	��Top=�6i   $��80��6�   ��6�   �� *Ctrl_1.RequestLevel2+�� 5$      -   5        $��btn_ReqLvl_3��5$      $��Stufe 3��6)   $
��Left=�6;   $��	10,91,0,0q�6V   $	��Top=�6i   $��80��6�   ��6�   �� *Ctrl_1.RequestLevel3+5%      �� 5'   
   $
��Left=�6   $	��158��6+   $��	138,8,0,0q�68   $	��Top=�6K   $	��158��6c   $,��&Properties/icon_be_und_entlueftung.png��6o   $
��Fill=�6�   �� 5(   
   -   5        $��Ckbx_DataLogger��5(      $!��Lüfterdaten Loggen EIN/AUS��6*   $
��Left=�6O   $��246,329,0,0q�6j   $	��Top=�6   $	��178��6�   ��6�   �� *Fan_1.OnOffLog+5*      5+      