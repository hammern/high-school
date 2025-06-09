IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
VarX dw 5
Var1 dw 10
var2 dw 9
const1 dw 40
const2 dw 50
const3 dw 31
const4 dw 9
min dw ?
max dw ?
ReturnAddress dw ?
; --------------------------
CODESEG

proc PrintX
	pop [ReturnAddress]
	pop cx
	
	cmp cx, 0
	jle NegetiveNum

Print:
	; Print one char (x)
	mov dl, 'x'
	mov ah, 2h
	int 21h
	
	loop Print

NegetiveNum:
	push [ReturnAddress]
	ret

endp PrintX


proc CheckBigEqualSmall
	pop [ReturnAddress]
	pop bx ; Var2
	pop ax ; Var1
	
	cmp ax, bx
	ja Var1GreaterThanVar2 ; if var1 > var2
	jb Var2GreaterThanVar1 ; if var2 > var1
	je Var1EqualsVar2 ; if var1 == var2

Var1GreaterThanVar2:
	; Print one char (A)
	mov dl, 'A'
	mov ah, 2h
	int 21h
	jmp EndCmp

Var2GreaterThanVar1:
	; Print one char (B)
	mov dl, 'B'
	mov ah, 2h
	int 21h
	jmp EndCmp

Var1EqualsVar2:
	; Print one char (C)
	mov dl, 'C'
	mov ah, 2h
	int 21h

EndCmp:
	push [ReturnAddress]
	ret

endp CheckBigEqualSmall


proc MinMax
	pop [ReturnAddress]
	mov cx, 3
	pop ax
	mov [min], ax
	mov [max], ax

CheckNum:
	pop ax
	cmp ax, [max]
	ja Greater
	cmp ax, [min]
	jb Lower
	jmp NextCheck

Greater:
	mov [max], ax
	jmp NextCheck

Lower:
	mov [min], ax

NextCheck:
	loop CheckNum
	push [ReturnAddress]
	ret
	
endp MinMax

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	push ax
	push dx
	push cx
	push [varX]
	call PrintX
	pop cx
	pop dx
	pop ax

	; Newline
	push ax
	push dx
	mov dl, 0ah
	mov ah, 2h
	int 21h
	pop dx
	pop ax
	
	push ax
	push bx
	push dx
	push [var1]
	push [var2]
	call CheckBigEqualSmall
	pop dx
	pop bx
	pop ax
	
	push ax
	push [const1]
	push [const2]
	push [const3]
	push [const4]
	call MinMax
	pop ax
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


