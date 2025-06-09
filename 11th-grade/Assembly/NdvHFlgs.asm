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

; zero flag - add
	mov al, 0FFh
	mov ah, 1h
	add al, ah

; zero flag - subtract
	mov ax, 10h
	sub ax, ax

; carry flag
	mov ax, 0FFFFh
	add ax, 1h

; sign flag
	mov al, 0Ah
	mov ah, 0Bh
	sub al, ah

; carry, zero and overflow
	mov ax, 128
	add al, 128

; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


