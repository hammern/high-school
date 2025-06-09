IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
	ArrA db 16 dup (6)
	ArrB dw 16 dup (6)
	ArrC db 20 dup (4,5,6)
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


