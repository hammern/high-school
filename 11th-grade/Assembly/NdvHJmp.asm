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
; skip command - ax = 4
xor ax, ax
jmp cs:000Ch
add ax, 5
add ax, 4

; skip command with label - ax = 4
xor ax, ax
jmp skip
add ax, 5
skip:
	add ax, 4
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


