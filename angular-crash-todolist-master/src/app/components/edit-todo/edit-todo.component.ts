import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/Todo';
import { TodoService } from 'src/app/services/todo.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-todo',
  templateUrl: './edit-todo.component.html',
  styleUrls: ['./edit-todo.component.css']
})
export class EditTodoComponent implements OnInit {
  todo:Todo;

  constructor(private todoService:TodoService, private route: ActivatedRoute) { 
    this.todo = new Todo();
  }

  ngOnInit() {
    const todoId = this.route.snapshot.paramMap.get("todoId");
    this.todoService.getTodo(todoId).subscribe(t => {
      this.todo = t;
    });      
    
  }

  onChange(todo:Todo){
    todo.completed = !todo.completed;
  }

  onSubmit(todo:Todo){
    this.todoService.toggleCompleted(todo).subscribe(t => {
      console.log(t);
    });
  }

}
