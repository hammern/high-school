IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
; Your variables here
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
	mov bx, 41h
	mov cx, 26
	
PrintAbc:
	mov dl, bl
	mov ah, 2
	int 21h
	inc bx
	
	loop PrintAbc
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


