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
xor ax, ax
mov al, 3
shl al, 2

xor ax, ax
mov al, 120
shr al, 3

xor ax, ax
mov al, 10
mov bl, al
shl al, 4
shl bl, 2
add al, bl
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


