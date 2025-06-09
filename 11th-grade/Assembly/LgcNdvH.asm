IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
Mask_4 db 00000011b
Mask_8 dw 0000000000000111b
Mask_Neg db 10000000b

TurnOn4_Mask db 00001000b
TurnOff2_5_Mask db 00010010b
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
xor ax, ax

mov al, 9
and al, [Mask_4]
mov al, 4
and al, [Mask_4]

mov ax, 9
mov ax, [Mask_8]
mov ax, 16
and ax, [Mask_8]

mov al, 4
and al, [Mask_Neg]
mov al, -4
and al, [Mask_Neg]

xor ax, ax
mov al, 1001011b
xor al, [TurnOff2_5_Mask]
xor al, [TurnOn4_Mask]
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


