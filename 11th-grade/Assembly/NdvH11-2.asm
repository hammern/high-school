IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
ReturnAddress dw ?

; Ex 1
ToIncrease dw 1

; Ex 2
Var1 dw 5
Var2 dw 10
Var3 dw 2
Var4 dw 12

; Ex 3
Swap1 dw 7
Swap2 dw 5
; --------------------------
CODESEG

proc Increase ; Ex 1
	pop [ReturnAddress]
	pop bx
	inc [byte ptr bx]
	push [ReturnAddress]
	ret
endp Increase

proc EquateToZero ; Ex 2
	pop [ReturnAddress]
	mov cx, 4

Equate:
	pop bx
	mov [byte ptr bx], 0
	loop Equate
	
	push [ReturnAddress]
	ret
endp EquateToZero

proc Swap ; Ex 3
	pop [ReturnAddress]
	pop bx ; Swap2
	pop ax ; Swap1
	
	mov cx, 2
	mov dx, [word ptr bx]
SwapNum:
	xchg ax, bx
	xchg [word ptr bx], dx
	loop SwapNum
	
	push [ReturnAddress]
	ret
endp Swap

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	push offset ToIncrease
	call Increase
	
	push offset var1
	push offset var2
	push offset var3
	push offset var4
	call EquateToZero
	
	push offset Swap1
	push offset Swap2
	call Swap
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


