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
mov ax, bx
mov ax, 5E6Dh
mov ah, bl
mov cl, 99
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start