using Microsoft.EntityFrameworkCore;

namespace tpmodul10_103022300027 {
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}

