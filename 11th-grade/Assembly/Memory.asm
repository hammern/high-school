IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
	my_name db 'Nadav Hammer'
	my_phone db '0587406336'
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
; Your code here
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


