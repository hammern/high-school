IDEAL
MODEL small
STACK 10h
DATASEG
; --------------------------
; Your variables here
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
mov ax, 1234h
push ax
pop bx
push 5678h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


